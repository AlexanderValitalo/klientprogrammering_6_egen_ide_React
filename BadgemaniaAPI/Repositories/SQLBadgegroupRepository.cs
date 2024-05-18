using BadgemaniaAPI.Data;
using BadgemaniaAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BadgemaniaAPI.Repositories
{
    public class SQLBadgegroupRepository : IBadgegroupRepository
    {
        private readonly BadgemaniaDbContext _dbContext;
        private readonly UserManager<CustomUser> _userManager;

        public SQLBadgegroupRepository(BadgemaniaDbContext dbContext, UserManager<CustomUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<List<Badgegroup>> GetAllAsync(string userId)
        {
            return await _dbContext.CustomUserBadgegroups.Where(c => c.CustomUserId == userId)
                .Select(b => b.Badgegroup).ToListAsync();
        }

        public async Task<Badgegroup?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Badgegroups.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Badgegroup> CreateAsync(string userID, Badgegroup badgegroup)
        {
            await _dbContext.Badgegroups.AddAsync(badgegroup);
            await _dbContext.SaveChangesAsync();

            var customUserEntity = await _dbContext.Users.Where(c => c.Id == userID).FirstOrDefaultAsync();

            var customUserBadgegroup = new CustomUserBadgegroup
            {
                CustomUser = customUserEntity,
                Badgegroup = badgegroup
            };

            await _dbContext.CustomUserBadgegroups.AddAsync(customUserBadgegroup);
            await _dbContext.SaveChangesAsync();

            return badgegroup;
        }

        public async Task<Badgegroup?> UpdateAsync(Guid id, Badgegroup badgegroup)
        {
            var existingBadgegroup = await _dbContext.Badgegroups.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadgegroup == null)
            {
                return null;
            }

            existingBadgegroup.Name = badgegroup.Name;

            await _dbContext.SaveChangesAsync();

            return existingBadgegroup;
        }

        public async Task<Badgegroup?> DeleteAsync(Guid id)
        {
            var existingBadgegroup = await _dbContext.Badgegroups.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadgegroup == null)
            {
                return null;
            }

            _dbContext.Badgegroups.Remove(existingBadgegroup);
            await _dbContext.SaveChangesAsync();

            return existingBadgegroup;
        }

        public async Task<List<CustomUser?>> GetAllStudentsInBadgegroupAsync(Guid badgegroupId)
        {
            var badgegroupEntity = await _dbContext.Badgegroups.Where(b => b.Id == badgegroupId).FirstOrDefaultAsync();
            if (badgegroupEntity == null)
            {
                return null;
            }

            var users = await _dbContext.CustomUserBadgegroups
                .Where(c => c.BadgegroupId == badgegroupId)
                .Select(c => c.CustomUser)
                .ToListAsync();

            var studentsInBadgegroup = new List<CustomUser?>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    studentsInBadgegroup.Add(user);
                }
            }

            return studentsInBadgegroup;
        }

        public async Task<CustomUserBadgegroup?> AddStudentToBadgegroupAsync(Guid badgegroupId, string studentId, Guid schoolId)
        {
            var badgegroupEntity = await _dbContext.Badgegroups.Where(b => b.Id == badgegroupId).FirstOrDefaultAsync();
            if (badgegroupEntity == null)
            {
                return null;
            }

            var customUserEntity = await _dbContext.Users.Where(c => c.Id == studentId).FirstOrDefaultAsync();
            if (customUserEntity == null)
            {
                return null;
            }

            if (customUserEntity.SchoolId != schoolId)
            {
                return null;
            }

            var customUserBadgegroup = new CustomUserBadgegroup
            {
                CustomUser = customUserEntity,
                Badgegroup = badgegroupEntity
            };

            await _dbContext.CustomUserBadgegroups.AddAsync(customUserBadgegroup);
            await _dbContext.SaveChangesAsync();

            return customUserBadgegroup;
        }

        public async Task<CustomUserBadgegroup?> RemoveStudentFromBadgegroupAsync(Guid badgegroupId, string studentId, Guid schoolId)
        {
            var customUserEntity = await _dbContext.Users.Where(c => c.Id == studentId).FirstOrDefaultAsync();
            if (customUserEntity == null)
            {
                return null;
            }

            if (customUserEntity.SchoolId != schoolId)
            {
                return null;
            }

            var customUserBadgegroup = await _dbContext.CustomUserBadgegroups.Where(c => c.CustomUserId == studentId && c.BadgegroupId == badgegroupId).FirstOrDefaultAsync();
            if (customUserBadgegroup == null)
            {
                return null;
            }

            _dbContext.CustomUserBadgegroups.Remove(customUserBadgegroup);
            await _dbContext.SaveChangesAsync();

            return customUserBadgegroup;
        }
    }
}

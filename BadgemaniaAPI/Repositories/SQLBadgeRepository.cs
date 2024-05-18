using BadgemaniaAPI.Data;
using BadgemaniaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BadgemaniaAPI.Repositories
{
    public class SQLBadgeRepository : IBadgeRepository
    {
        private readonly BadgemaniaDbContext _dbContext;

        public SQLBadgeRepository(BadgemaniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Badge>> GetAllAsync(string userId)
        {
            return await _dbContext.CustomUserBadges.Where(c => c.CustomUserId == userId).Select(b => b.Badge).ToListAsync();
            //return await _dbContext.Badges.Include(b => b.Badegroup).Include(t => t.Badgetype).ToListAsync();
        }

        public async Task<Badge?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Badges.Include(b => b.Badegroup).Include(t => t.Badgetype).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Badge> CreateAsync(Badge badge)
        {
            await _dbContext.Badges.AddAsync(badge);
            await _dbContext.SaveChangesAsync();

            return badge;
        }

        public async Task<Badge?> UpdateAsync(Guid id, Badge badge)
        {
            var existingBadge = await _dbContext.Badges.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadge == null)
            {
                return null;
            }

            existingBadge.Title = badge.Title;
            existingBadge.Description = badge.Description;
            existingBadge.Score = badge.Score;
            existingBadge.BadgeImageUrl = badge.BadgeImageUrl;

            await _dbContext.SaveChangesAsync();

            return existingBadge;
        }

        public async Task<Badge?> DeleteAsync(Guid id)
        {
            var existingBadge = await _dbContext.Badges.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadge == null)
            {
                return null;
            }

            _dbContext.Badges.Remove(existingBadge);
            await _dbContext.SaveChangesAsync();

            return existingBadge;
        }

        public async Task<CustomUserBadge?> AddBadgeToStudentAsync(Guid badgeId, string studentId)
        {
            var badgeEntity = await _dbContext.Badges.Where(b => b.Id == badgeId).FirstOrDefaultAsync();
            if (badgeEntity == null)
            {
                return null;
            }

            var customUserEntity = await _dbContext.Users.Where(c => c.Id == studentId).FirstOrDefaultAsync();
            if (customUserEntity == null)
            {
                return null;
            }

            var customUserBadge = new CustomUserBadge
            {
                CustomUser = customUserEntity,
                Badge = badgeEntity
            };

            await _dbContext.CustomUserBadges.AddAsync(customUserBadge);
            await _dbContext.SaveChangesAsync();

            return customUserBadge;
        }

        public async Task<CustomUserBadge?> RemoveBadgeFromStudentAsync(Guid badgeId, string studentId)
        {
            var customUserBadge = await _dbContext.CustomUserBadges.Where(c => c.BadgeId == badgeId && c.CustomUserId == studentId).FirstOrDefaultAsync();
            if (customUserBadge == null)
            {
                return null;
            }

            _dbContext.CustomUserBadges.Remove(customUserBadge);
            await _dbContext.SaveChangesAsync();

            return customUserBadge;
        }
    }
}

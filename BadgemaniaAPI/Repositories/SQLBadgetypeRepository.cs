using BadgemaniaAPI.Data;
using BadgemaniaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BadgemaniaAPI.Repositories
{
    public class SQLBadgetypeRepository : IBadgetypeRepository
    {
        private readonly BadgemaniaDbContext _dbContext;

        public SQLBadgetypeRepository(BadgemaniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Badgetype>> GetAllAsync()
        {
            return await _dbContext.Badgetypes.Include(b => b.Badges).Include(g => g.Badgegroup).ToListAsync();
        }

        public async Task<Badgetype?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Badgetypes.Include(b => b.Badges).Include(g => g.Badgegroup).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Badgetype> CreateAsync(Badgetype badgetype)
        {
            await _dbContext.Badgetypes.AddAsync(badgetype);
            await _dbContext.SaveChangesAsync();

            return badgetype;
        }

        public async Task<Badgetype?> UpdateAsync(Guid id, Badgetype badgetype)
        {
            var existingBadgetype = await _dbContext.Badgetypes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadgetype == null)
            {
                return null;
            }

            existingBadgetype.Title = badgetype.Title;

            await _dbContext.SaveChangesAsync();

            return existingBadgetype;
        }

        public async Task<Badgetype?> DeleteAsync(Guid id)
        {
            var existingBadgetype = await _dbContext.Badgetypes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBadgetype == null)
            {
                return null;
            }

            _dbContext.Badgetypes.Remove(existingBadgetype);
            await _dbContext.SaveChangesAsync();

            return existingBadgetype;
        }
    }
}

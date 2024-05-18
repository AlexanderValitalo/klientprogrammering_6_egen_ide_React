using BadgemaniaAPI.Data;
using BadgemaniaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BadgemaniaAPI.Repositories
{
    public class SQLSchoolRepository : ISchoolRepository
    {
        private readonly BadgemaniaDbContext _dbContext;

        public SQLSchoolRepository(BadgemaniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<School>> GetAllAsync()
        {
            return await _dbContext.Schools.Include(c => c.CustomUsers).ToListAsync();
        }

        public async Task<School?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Schools.Include(c => c.CustomUsers).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<School> CreateAsync(School school)
        {
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();

            return school;
        }

        public async Task<School?> UpdateAsync(Guid id, School school)
        {
            var existingSchool = await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSchool == null)
            {
                return null;
            }

            existingSchool.Name = school.Name;

            await _dbContext.SaveChangesAsync();

            return existingSchool;
        }

        public async Task<School?> DeleteAsync(Guid id)
        {
            var existingSchool = await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSchool == null)
            {
                return null;
            }

            _dbContext.Schools.Remove(existingSchool);
            await _dbContext.SaveChangesAsync();

            return existingSchool;
        }
    }
}

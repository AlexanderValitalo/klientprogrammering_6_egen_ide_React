using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Repositories
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllAsync();

        Task<School?> GetByIdAsync(Guid id);

        Task<School> CreateAsync(School school);

        Task<School?> UpdateAsync(Guid id, School school);

        Task<School?> DeleteAsync(Guid id);
    }
}

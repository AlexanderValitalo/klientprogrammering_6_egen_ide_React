using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Repositories
{
    public interface IBadgetypeRepository
    {
        Task<List<Badgetype>> GetAllAsync();

        Task<Badgetype?> GetByIdAsync(Guid id);

        Task<Badgetype> CreateAsync(Badgetype badgetype);

        Task<Badgetype?> UpdateAsync(Guid id, Badgetype badgetype);

        Task<Badgetype?> DeleteAsync(Guid id);
    }
}

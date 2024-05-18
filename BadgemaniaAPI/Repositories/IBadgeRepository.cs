using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Repositories
{
    public interface IBadgeRepository
    {
        Task<List<Badge>> GetAllAsync(string userId);

        Task<Badge?> GetByIdAsync(Guid id);

        Task<Badge> CreateAsync(Badge badge);

        Task<Badge?> UpdateAsync(Guid id, Badge badge);

        Task<Badge?> DeleteAsync(Guid id);

        Task<CustomUserBadge?> AddBadgeToStudentAsync(Guid badgeId, string studentId);

        Task<CustomUserBadge?> RemoveBadgeFromStudentAsync(Guid badgeId, string studentId);
    }
}

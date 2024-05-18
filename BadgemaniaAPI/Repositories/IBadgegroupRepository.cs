using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Repositories
{
    public interface IBadgegroupRepository
    {
        Task<List<Badgegroup>> GetAllAsync(string userId);

        Task<Badgegroup?> GetByIdAsync(Guid id);

        Task<Badgegroup> CreateAsync(string userId, Badgegroup badgegroup);

        Task<Badgegroup?> UpdateAsync(Guid id, Badgegroup badgegroup);

        Task<Badgegroup?> DeleteAsync(Guid id);

        Task<List<CustomUser?>> GetAllStudentsInBadgegroupAsync(Guid badgegroupId);

        Task<CustomUserBadgegroup?> AddStudentToBadgegroupAsync(Guid badgegroupId, string studentId, Guid schoolId);

        Task<CustomUserBadgegroup?> RemoveStudentFromBadgegroupAsync(Guid badgegroupId, string studentId, Guid schoolId);
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BadgemaniaAPI.Models.Domain
{
    public class CustomUser : IdentityUser
    {
        [ForeignKey(nameof(School))]
        public Guid? SchoolId { get; set; }

        public School? School { get; set; }

        public ICollection<CustomUserBadgegroup> CustomUserBadgegroups { get; set; } = new List<CustomUserBadgegroup>();

        public ICollection<CustomUserBadge> CustomUserBadges { get; set; } = new List<CustomUserBadge>();

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime TokenExpires { get; set; }
    }
}

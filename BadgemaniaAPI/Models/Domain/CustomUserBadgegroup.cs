namespace BadgemaniaAPI.Models.Domain
{
    public class CustomUserBadgegroup
    {
        public string CustomUserId { get; set; }

        public Guid BadgegroupId { get; set; }

        public CustomUser CustomUser { get; set; }

        public Badgegroup Badgegroup { get; set; }
    }
}

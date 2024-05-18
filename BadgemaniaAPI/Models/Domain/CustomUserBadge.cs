namespace BadgemaniaAPI.Models.Domain
{
    public class CustomUserBadge
    {
        public string CustomUserId { get; set; }

        public Guid BadgeId { get; set; }

        public CustomUser CustomUser { get; set; }

        public Badge Badge { get; set; }
    }
}

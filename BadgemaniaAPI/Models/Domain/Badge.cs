namespace BadgemaniaAPI.Models.Domain
{
    public class Badge
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public string? BadgeImageUrl { get; set; }

        public Guid BadgetypeId { get; set; }

        public Guid? BadgegroupId { get; set; }

        public Badgetype Badgetype { get; set; }

        public Badgegroup Badegroup { get; set; }

        public ICollection<CustomUserBadge> CustomUserBadges { get; set; } = new List<CustomUserBadge>();
    }
}

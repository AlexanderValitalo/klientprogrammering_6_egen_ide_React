namespace BadgemaniaAPI.Models.Domain
{
    public class Badgegroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Badge> Badges { get; set; } = new List<Badge>();

        public ICollection<Badgetype> Badgetypes { get; set; } = new List<Badgetype>();

        public ICollection<CustomUserBadgegroup> CustomUserBadgegroups { get; set; } = new List<CustomUserBadgegroup>();
    }
}

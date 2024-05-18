namespace BadgemaniaAPI.Models.Domain
{
    public class Badgetype
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<Badge> Badges { get; set; } = new List<Badge>();

        public Guid BadgegroupId { get; set; }

        public Badgegroup Badgegroup { get; set; }
    }
}

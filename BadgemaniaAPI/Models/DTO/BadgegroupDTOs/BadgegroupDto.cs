using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Models.DTO.BadgegroupDTOs
{
    public class BadgegroupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Badge> Badges { get; set; } = new List<Badge>();

        public ICollection<Badgetype> Badgetypes { get; set; } = new List<Badgetype>();
    }
}

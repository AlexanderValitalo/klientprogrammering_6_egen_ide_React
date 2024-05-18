using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.BadgegroupDTOs;

namespace BadgemaniaAPI.Models.DTO.BadgetypeDTOs
{
    public class BadgetypeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<Badge> Badges { get; set; } = new List<Badge>();

        public BadgegroupDto Badgegroup { get; set; }
    }
}

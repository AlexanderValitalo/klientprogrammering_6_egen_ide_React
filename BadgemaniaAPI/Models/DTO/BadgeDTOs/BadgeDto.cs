using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Models.DTO.BadgeDTOs
{
    public class BadgeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public string? BadgeImageUrl { get; set; }

        public Badgetype Badgetype { get; set; }

        public Badgegroup Badegroup { get; set; }
    }
}

namespace BadgemaniaAPI.Models.DTO.BadgeDTOs
{
    public class CreatedBadgeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public string? BadgeImageUrl { get; set; }

        public Guid BadgetypeId { get; set; }

        public Guid? BadgegroupId { get; set; }
    }
}

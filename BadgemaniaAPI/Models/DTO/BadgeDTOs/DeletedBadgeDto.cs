namespace BadgemaniaAPI.Models.DTO.BadgeDTOs
{
    public class DeletedBadgeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? BadgeImageUrl { get; set; }
    }
}

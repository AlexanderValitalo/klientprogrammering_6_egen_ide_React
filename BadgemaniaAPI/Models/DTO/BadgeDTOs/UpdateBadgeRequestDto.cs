using System.ComponentModel.DataAnnotations;

namespace BadgemaniaAPI.Models.DTO.BadgeDTOs
{
    public class UpdateBadgeRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title can only be a maximum of 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Description can only be a maximum of 200 characters")]
        public string Description { get; set; }

        [Required]
        public int Score { get; set; }

        public string? BadgeImageUrl { get; set; }
    }
}

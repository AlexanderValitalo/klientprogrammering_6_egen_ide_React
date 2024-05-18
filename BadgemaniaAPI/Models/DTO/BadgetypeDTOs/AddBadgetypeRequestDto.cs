using System.ComponentModel.DataAnnotations;

namespace BadgemaniaAPI.Models.DTO.BadgetypeDTOs
{
    public class AddBadgetypeRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title can only be a maximum of 100 characters")]
        public string Title { get; set; }

        [Required]
        public Guid BadgegroupId { get; set; }
    }
}

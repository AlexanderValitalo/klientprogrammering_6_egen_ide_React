using System.ComponentModel.DataAnnotations;

namespace BadgemaniaAPI.Models.DTO.BadgegroupDTOs
{
    public class UpdateBadgegroupRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name can only be a maximum of 100 characters")]
        public string Name { get; set; }
    }
}

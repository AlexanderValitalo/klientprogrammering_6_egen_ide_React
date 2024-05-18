using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Models.DTO.SchoolDTOs
{
    public class SchoolDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<CustomUser> CustomUsers { get; set; } = new List<CustomUser>();
    }
}

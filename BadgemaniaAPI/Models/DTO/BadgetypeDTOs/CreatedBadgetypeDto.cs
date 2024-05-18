namespace BadgemaniaAPI.Models.DTO.BadgetypeDTOs
{
    public class CreatedBadgetypeDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid BadgegroupId { get; set; }
    }
}

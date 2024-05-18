namespace BadgemaniaAPI.Models.Domain
{
    public class School
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<CustomUser> CustomUsers { get; set; } = new List<CustomUser>();
    }
}

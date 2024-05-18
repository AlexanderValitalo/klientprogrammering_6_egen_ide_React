namespace BadgemaniaAPI.Models.DTO.AuthDTOs
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }

        public DateTime Expires { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}

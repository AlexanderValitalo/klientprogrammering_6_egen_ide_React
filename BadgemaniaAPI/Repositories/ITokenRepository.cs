using BadgemaniaAPI.Models.Domain;

namespace BadgemaniaAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(CustomUser user, List<string> roles);

        RefreshToken GenerateRefreshToken(string userId);

        Task<CustomUser?> GetUserFromRefreshToken(string refreshToken);

        CookieOptions SetRefreshToken(RefreshToken newRefreshToken);
    }
}

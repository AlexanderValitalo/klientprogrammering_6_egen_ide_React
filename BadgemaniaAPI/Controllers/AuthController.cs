using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.AuthDTOs;
using BadgemaniaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BadgemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<CustomUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        // POST: /api/Auth/RegisterSchool
        [HttpPost]
        [Route("RegisterSchoolAdmin")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> RegisterSchool([FromBody] RegisterSchoolAdminRequestDto registerSchoolAdminRequestDto)
        {
            var customUser = new CustomUser
            {
                UserName = registerSchoolAdminRequestDto.Username,
                Email = registerSchoolAdminRequestDto.Username,
                SchoolId = registerSchoolAdminRequestDto.SchoolId,
            };

            var identityResult = await _userManager.CreateAsync(customUser, registerSchoolAdminRequestDto.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(customUser, ["SchoolAdmin"]);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login.");
                }
            }

            return BadRequest("Something went wrong");
        }

        // POST: /api/Auth/RegisterTeacher
        [HttpPost]
        [Route("RegisterTeacher")]
        [Authorize(Roles = "SchoolAdmin")]
        public async Task<IActionResult> RegisterTeacher([FromBody] RegisterTeacherRequestDto registerTeacherRequestDto)
        {
            var customUser = new CustomUser
            {
                UserName = registerTeacherRequestDto.Username,
                Email = registerTeacherRequestDto.Username,
                SchoolId = Guid.Parse(HttpContext.User.FindFirstValue("schoolID"))
            };

            var identityResult = await _userManager.CreateAsync(customUser, registerTeacherRequestDto.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(customUser, ["Teacher"]);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login.");
                }
            }

            return BadRequest("Something went wrong");
        }

        // POST: /api/Auth/RegisterStudent
        [HttpPost]
        [Route("RegisterStudent")]
        [Authorize(Roles = "SchoolAdmin")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentRequestDto registerStudentRequestDto)
        {
            var customUser = new CustomUser
            {
                UserName = registerStudentRequestDto.Username,
                Email = registerStudentRequestDto.Username,
                SchoolId = Guid.Parse(HttpContext.User.FindFirstValue("schoolID"))
            };

            var identityResult = await _userManager.CreateAsync(customUser, registerStudentRequestDto.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(customUser, ["Student"]);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login.");
                }
            }

            return BadRequest("Something went wrong");
        }

        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            Console.WriteLine(user);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

                        var jwtExpires = GetExpirationTime(jwtToken);

                        var refreshToken = _tokenRepository.GenerateRefreshToken(user.Id);

                        var cookieOptions = _tokenRepository.SetRefreshToken(refreshToken);

                        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

                        user.RefreshToken = refreshToken.Token;
                        user.TokenExpires = refreshToken.Expires;

                        await _userManager.UpdateAsync(user);

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                            Expires = jwtExpires,
                            Roles = roles
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password is incorrect");
        }

        // POST: /api/Auth/RefreshToken
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _tokenRepository.GetUserFromRefreshToken(refreshToken);

            if (user == null)
            {
                return Unauthorized("User not found");
            }

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token");
            }
            else if (user.TokenExpires < DateTime.UtcNow)
            {
                return Unauthorized("Token expired");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles != null)
            {
                var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

                var jwtExpires = GetExpirationTime(jwtToken);

                var newRefreshToken = _tokenRepository.GenerateRefreshToken(user.Id);

                var cookieOptions = _tokenRepository.SetRefreshToken(newRefreshToken);

                Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

                user.RefreshToken = newRefreshToken.Token;
                user.TokenExpires = newRefreshToken.Expires;

                await _userManager.UpdateAsync(user);

                var response = new RefreshTokenResponseDto
                {
                    JwtToken = jwtToken,
                    Expires = jwtExpires,
                    Roles = roles
                };

                return Ok(response);
            }
            return BadRequest("Login again");
        }

        // POST: /api/Auth/Logout
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true, // Match the HttpOnly flag of the original cookie
                                 // Add any other options that were set when the cookie was created
                Secure = true,
                SameSite = SameSiteMode.Lax,
            };

            Response.Cookies.Append("refreshToken", "", cookieOptions);

            return Ok("Logged out successfully");
        }

        // Get: /api/Auth/StudentsFromSchool
        [HttpGet]
        [Route("StudentsFromSchool")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> StudentsFromSchool()
        {
            var schoolId = Guid.Parse(HttpContext.User.FindFirstValue("schoolID"));

            var users = await _userManager.Users.Where(u => u.SchoolId == schoolId).ToListAsync();

            users = users.Where(u => _userManager.IsInRoleAsync(u, "Student").Result).ToList();

            if (users != null)
            {
                List<UserDto> usersDto = new List<UserDto>();

                foreach (var user in users)
                {
                    var userDto = new UserDto
                    {
                        Id = user.Id,
                        Username = user.UserName
                    };

                    usersDto.Add(userDto);
                }
                return Ok(usersDto);
            }

            return BadRequest("No users found");
        }

        private DateTime GetExpirationTime(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            return token.ValidTo;
        }

        private string GetRole(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            return token.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        }
    }
}

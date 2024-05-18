using BadgemaniaAPI.CustomActionFilters;
using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.BadgeDTOs;
using BadgemaniaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BadgemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeRepository _badgeRepository;

        public BadgesController(IBadgeRepository badgeRepository)
        {
            _badgeRepository = badgeRepository;
        }

        // GET ALL BADGES
        // GET: https://localhost:7280/api/Badges
        [HttpGet]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue("userID");

            var badges = await _badgeRepository.GetAllAsync(userId);

            var badgeDto = new List<BadgeDto>();
            foreach (var badge in badges)
            {
                badgeDto.Add(new BadgeDto()
                {
                    Id = badge.Id,
                    Title = badge.Title,
                    Description = badge.Description,
                    Score = badge.Score,
                    BadgeImageUrl = badge.BadgeImageUrl,
                    Badgetype = badge.Badgetype,
                    Badegroup = badge.Badegroup,
                });
            }

            return Ok(badgeDto);
        }

        // GET SINGLE BADGE (Get Badge By ID)
        // GET: https://localhost:7280/api/Badges/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var badge = await _badgeRepository.GetByIdAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            var badgeDto = new BadgeDto
            {
                Id = badge.Id,
                Title = badge.Title,
                Description = badge.Description,
                Score = badge.Score,
                BadgeImageUrl = badge.BadgeImageUrl,
                Badgetype = badge.Badgetype,
                Badegroup = badge.Badegroup,
            };

            return Ok(badgeDto);
        }

        // POST To Create New Badge
        // POST: https://localhost:7280/api/Badges
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([FromBody] AddBadgeRequestDto addBadgeRequestDto)
        {
            // Convert DTO to Domain Model
            var badge = new Badge
            {
                Title = addBadgeRequestDto.Title,
                Description = addBadgeRequestDto.Description,
                Score = addBadgeRequestDto.Score,
                BadgeImageUrl = addBadgeRequestDto.BadgeImageUrl,
                BadgetypeId = addBadgeRequestDto.BadgetypeId,
                BadgegroupId = addBadgeRequestDto.BadgegroupId,
            };

            // Use Domain Model to create Region
            badge = await _badgeRepository.CreateAsync(badge);

            // Map Domain model back to DTO
            var createdBadgeDto = new CreatedBadgeDto
            {
                Id = badge.Id,
                Title = badge.Title,
                Description = badge.Description,
                Score = badge.Score,
                BadgeImageUrl = badge.BadgeImageUrl,
                BadgetypeId = badge.BadgetypeId,
                BadgegroupId = badge.BadgegroupId,
            };

            return CreatedAtAction(nameof(GetById), new { id = createdBadgeDto.Id }, createdBadgeDto);
        }

        // Update Badge By Id
        // PUT: https://localhost:7280/api/Badges/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBadgeRequestDto updateBadgeRequestDto)
        {
            // Map DTO to Domain Model
            var badge = new Badge
            {
                Title = updateBadgeRequestDto.Title,
                Description = updateBadgeRequestDto.Description,
                Score = updateBadgeRequestDto.Score,
                BadgeImageUrl = updateBadgeRequestDto.BadgeImageUrl,
            };

            /// Check if badgegroup exists
            badge = await _badgeRepository.UpdateAsync(id, badge);

            if (badge == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO and return Ok
            var updatedBadgeDto = new UpdatedBadgeDto
            {
                Id = badge.Id,
                Title = badge.Title,
                Description = badge.Description,
                BadgeImageUrl = badge.BadgeImageUrl
            };

            return Ok(updatedBadgeDto);
        }

        // Delete badge
        // Delete: https://localhost:7280/api/Badges/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var badge = await _badgeRepository.DeleteAsync(id);

            if (badge == null)
            {
                return NotFound();
            }

            // map Domain Model to DTO
            var deletedBadgeDto = new DeletedBadgeDto
            {
                Id = badge.Id,
                Title = badge.Title,
                Description = badge.Description,
                BadgeImageUrl = badge.BadgeImageUrl
            };

            // Can also just send empty Ok() back instead
            return Ok(deletedBadgeDto);
        }

        // Add badge to student
        // PUT: https://localhost:7280/api/Badges/{id}/AddToStudent/{studentId}
        [HttpPut]
        [Route("{id:Guid}/AddToStudent/{studentId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddBadgeToStudent([FromRoute] Guid id, [FromRoute] string studentId)
        {
            var customUserBadge = await _badgeRepository.AddBadgeToStudentAsync(id, studentId);

            if (customUserBadge == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // Remove badge from student
        // PUT: https://localhost:7280/api/Badges/{id}/RemoveFromStudent/{studentId}
        [HttpPut]
        [Route("{id:Guid}/RemoveFromStudent/{studentId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> RemoveBadgeFromStudent([FromRoute] Guid id, [FromRoute] string studentId)
        {
            var customUserBadge = await _badgeRepository.RemoveBadgeFromStudentAsync(id, studentId);

            if (customUserBadge == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

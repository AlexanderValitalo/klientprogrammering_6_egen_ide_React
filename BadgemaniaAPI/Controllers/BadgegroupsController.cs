using BadgemaniaAPI.CustomActionFilters;
using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.BadgegroupDTOs;
using BadgemaniaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BadgemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgegroupsController : ControllerBase
    {
        private readonly IBadgegroupRepository _badgegroupRepository;

        public BadgegroupsController(IBadgegroupRepository badgegroupRepository)
        {
            _badgegroupRepository = badgegroupRepository;
        }

        // GET ALL BADGEGROUPS
        // GET: https://localhost:7280/api/Badgegroups
        [HttpGet]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue("userID");

            var badgegroups = await _badgegroupRepository.GetAllAsync(userId);

            var badgegroupsDto = new List<BadgegroupsDto>();
            foreach (var badgegroup in badgegroups)
            {
                badgegroupsDto.Add(new BadgegroupsDto()
                {
                    Id = badgegroup.Id,
                    Name = badgegroup.Name,
                    //Badges = badgegroup.Badges,
                    //Badgetypes = badgegroup.Badgetypes
                });
            }

            return Ok(badgegroupsDto);
        }

        // GET SINGLE BADGEGROUP (Get Badgegroup By ID)
        // GET: https://localhost:7280/api/Badgegroups/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var badgegroup = await _badgegroupRepository.GetByIdAsync(id);

            if (badgegroup == null)
            {
                return NotFound();
            }

            var badgegroupDto = new BadgegroupDto
            {
                Id = badgegroup.Id,
                Name = badgegroup.Name,
                Badges = badgegroup.Badges,
                Badgetypes = badgegroup.Badgetypes
            };

            return Ok(badgegroupDto);
        }

        // POST To Create New Badgegroup
        // POST: https://localhost:7280/api/Badgegroups
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([FromBody] AddBadgegroupRequestDto addBadgegroupRequestDto)
        {
            // Convert DTO to Domain Model
            var badgegroup = new Badgegroup
            {
                Name = addBadgegroupRequestDto.Name,
                //CustomUserId = HttpContext.User.FindFirstValue("userID")
            };

            var userId = HttpContext.User.FindFirstValue("userID");
            // Use Domain Model to create Region
            badgegroup = await _badgegroupRepository.CreateAsync(userId, badgegroup);



            // Map Domain model back to DTO
            var createdBadgegroupDto = new CreatedBadgegroupDto
            {
                Id = badgegroup.Id,
                Name = badgegroup.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = createdBadgegroupDto.Id }, createdBadgegroupDto);
        }

        // Update badgegroup
        // PUT: https://localhost:7280/api/Badgegroups/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBadgegroupRequestDto updateBadgegroupRequestDto)
        {
            // Map DTO to Domain Model
            var badgegroup = new Badgegroup
            {
                Name = updateBadgegroupRequestDto.Name,
            };

            // Check if badgegroup exists
            badgegroup = await _badgegroupRepository.UpdateAsync(id, badgegroup);

            if (badgegroup == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO and return Ok
            var updatedBadgegroupDto = new UpdatedBadgegroupDto
            {
                Id = badgegroup.Id,
                Name = badgegroup.Name,
            };

            return Ok(updatedBadgegroupDto);
        }

        // Delete badgegroup
        // Delete: https://localhost:7280/api/Badgegroups/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var badgegroup = await _badgegroupRepository.DeleteAsync(id);

            if (badgegroup == null)
            {
                return NotFound();
            }

            // map Domain Model to DTO
            var deletedBadgegroupDto = new DeletedBadgegroupDto
            {
                Id = badgegroup.Id,
                Name = badgegroup.Name,
            };

            // Can also just send empty Ok() back instead
            return Ok(deletedBadgegroupDto);
        }

        // Get all students in badgegroup
        // GET: https://localhost:7280/api/Badgegroups/{id}/Students
        [HttpGet]
        [Route("{id:Guid}/Students")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllStudentsInBadgegroup([FromRoute] Guid id)
        {
            var studentsInBadgegroup = await _badgegroupRepository.GetAllStudentsInBadgegroupAsync(id);
            if (studentsInBadgegroup == null)
            {
                return NotFound();
            }

            var studentsInBadgegroupDto = new List<StudentsInBadgegroupResponseDto>();
            foreach (var student in studentsInBadgegroup)
            {
                studentsInBadgegroupDto.Add(new StudentsInBadgegroupResponseDto()
                {
                    StudentId = student.Id,
                    StudentEmail = student.Email
                });
            }

            return Ok(studentsInBadgegroupDto);
        }

        // Add student to badgegroup
        // PUT: https://localhost:7280/api/Badgegroups/{id}/AddStudent/{studentId}
        [HttpPut]
        [Route("{id:Guid}/AddStudent/{studentId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddStudentToBadgegroup([FromRoute] Guid id, [FromRoute] string studentId)
        {
            var schoolId = Guid.Parse(HttpContext.User.FindFirstValue("schoolID"));

            var customUserBadgegroup = await _badgegroupRepository.AddStudentToBadgegroupAsync(id, studentId, schoolId);

            if (customUserBadgegroup == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // Remove student from badgegroup
        // PUT: https://localhost:7280/api/Badgegroups/{id}/RemoveStudent/{studentId}
        [HttpPut]
        [Route("{id:Guid}/RemoveStudent/{studentId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> RemoveStudentFromBadgegroup([FromRoute] Guid id, [FromRoute] string studentId)
        {
            var schoolId = Guid.Parse(HttpContext.User.FindFirstValue("schoolID"));

            var customUserBadgegroup = await _badgegroupRepository.RemoveStudentFromBadgegroupAsync(id, studentId, schoolId);

            if (customUserBadgegroup == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

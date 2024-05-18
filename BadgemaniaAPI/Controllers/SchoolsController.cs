using BadgemaniaAPI.CustomActionFilters;
using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.SchoolDTOs;
using BadgemaniaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BadgemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // GET ALL SCHOOLS
        // GET: https://localhost:7280/api/Schools
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAll()
        {
            var schools = await _schoolRepository.GetAllAsync();

            var schoolDto = new List<SchoolDto>();
            foreach (var school in schools)
            {
                schoolDto.Add(new SchoolDto()
                {
                    Id = school.Id,
                    Name = school.Name,
                    CustomUsers = school.CustomUsers,
                });
            }

            return Ok(schoolDto);
        }

        // GET SINGLE SCHOOL (Get SCHOOL By ID)
        // GET: https://localhost:7280/api/Schools/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            var schoolDto = new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                CustomUsers = school.CustomUsers,
            };

            // Return DTO back to client
            return Ok(schoolDto);
        }

        // POST To Create New School
        // POST: https://localhost:7280/api/Schools
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create([FromBody] AddSchoolRequestDto addSchoolRequestDto)
        {
            // Convert DTO to Domain Model
            var school = new School
            {
                Name = addSchoolRequestDto.Name,
            };

            // Use Domain Model to create Region
            school = await _schoolRepository.CreateAsync(school);

            // Map Domain model back to DTO
            var createdSchoolDto = new CreatedSchoolDto
            {
                Id = school.Id,
                Name = school.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = createdSchoolDto.Id }, createdSchoolDto);
        }

        // Update School By Id
        // PUT: https://localhost:7280/api/Schools/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSchoolRequestDto updateSchoolRequestDto)
        {
            // Map DTO to Domain Model
            var school = new School
            {
                Name = updateSchoolRequestDto.Name,
            };

            /// Check if badgegroup exists
            school = await _schoolRepository.UpdateAsync(id, school);

            if (school == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO and return Ok
            var updatedSchoolDto = new UpdatedSchoolDto
            {
                Id = school.Id,
                Name = school.Name,
            };

            return Ok(updatedSchoolDto);
        }

        // Delete school
        // Delete: https://localhost:7280/api/Schools/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var school = await _schoolRepository.DeleteAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            // map Domain Model to DTO
            var deletedSchoolDto = new DeletedSchoolDto
            {
                Id = school.Id,
                Name = school.Name,
            };

            // Can also just send empty Ok() back instead
            return Ok(deletedSchoolDto);
        }
    }
}

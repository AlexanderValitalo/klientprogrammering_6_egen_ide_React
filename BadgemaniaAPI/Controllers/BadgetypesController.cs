using BadgemaniaAPI.CustomActionFilters;
using BadgemaniaAPI.Models.Domain;
using BadgemaniaAPI.Models.DTO.BadgegroupDTOs;
using BadgemaniaAPI.Models.DTO.BadgetypeDTOs;
using BadgemaniaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BadgemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgetypesController : ControllerBase
    {
        private readonly IBadgetypeRepository _badgetypeRepository;

        public BadgetypesController(IBadgetypeRepository badgetypeRepository)
        {
            _badgetypeRepository = badgetypeRepository;
        }

        // GET ALL BADGETYPES
        // GET: https://localhost:7280/api/Badgetypes
        [HttpGet]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetAll()
        {
            var badgetypes = await _badgetypeRepository.GetAllAsync();

            var badgetypesDto = new List<BadgetypesDto>();
            foreach (var badgetype in badgetypes)
            {
                badgetypesDto.Add(new BadgetypesDto()
                {
                    Id = badgetype.Id,
                    Title = badgetype.Title,
                    //Badges = badgetype.Badges,
                    //Badgegroup = new BadgegroupDto
                    //{
                    //    Id = badgetype.Badgegroup.Id,
                    //    Name = badgetype.Badgegroup.Name,
                    //    Badges = badgetype.Badgegroup.Badges,
                    //    Badgetypes = badgetype.Badgegroup.Badgetypes
                    //}
                });
            }

            return Ok(badgetypesDto);
        }

        // GET SINGLE BADGETYPE (Get BADGETYPE By ID)
        // GET: https://localhost:7280/api/Badgetypes/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var badgetype = await _badgetypeRepository.GetByIdAsync(id);

            if (badgetype == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            var badgetypeDto = new BadgetypeDto
            {
                Id = badgetype.Id,
                Title = badgetype.Title,
                Badges = badgetype.Badges,
                Badgegroup = new BadgegroupDto
                {
                    Id = badgetype.Badgegroup.Id,
                    Name = badgetype.Badgegroup.Name,
                    Badges = badgetype.Badgegroup.Badges,
                    Badgetypes = badgetype.Badgegroup.Badgetypes
                }
            };

            // Return DTO back to client
            return Ok(badgetypeDto);
        }

        // POST To Create New Badgetype
        // POST: https://localhost:7280/api/Badgetypes
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([FromBody] AddBadgetypeRequestDto addBadgetypeRequestDto)
        {
            // Convert DTO to Domain Model
            var badgetype = new Badgetype
            {
                Title = addBadgetypeRequestDto.Title,
                BadgegroupId = addBadgetypeRequestDto.BadgegroupId,
            };

            // Use Domain Model to create Region
            badgetype = await _badgetypeRepository.CreateAsync(badgetype);

            // Map Domain model back to DTO
            var createdBadgetypeDto = new CreatedBadgetypeDto
            {
                Id = badgetype.Id,
                Title = badgetype.Title,
                BadgegroupId = badgetype.BadgegroupId,
            };

            return CreatedAtAction(nameof(GetById), new { id = createdBadgetypeDto.Id }, createdBadgetypeDto);
        }

        // Update Badgetype By Id
        // PUT: https://localhost:7280/api/Badgetypes/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBadgetypeRequestDto updateBadgetypeRequestDto)
        {
            // Map DTO to Domain Model
            var badgetype = new Badgetype
            {
                Title = updateBadgetypeRequestDto.Title
            };

            /// Check if badgegroup exists
            badgetype = await _badgetypeRepository.UpdateAsync(id, badgetype);

            if (badgetype == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO and return Ok
            var updatedBadgetypeDto = new UpdatedBadgetypeDto
            {
                Id = badgetype.Id,
                Title = badgetype.Title,
            };

            return Ok(updatedBadgetypeDto);
        }

        // Delete badgetype
        // Delete: https://localhost:7280/api/Badgetypes/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var badgetype = await _badgetypeRepository.DeleteAsync(id);

            if (badgetype == null)
            {
                return NotFound();
            }

            // map Domain Model to DTO
            var deletedBadgetypeDto = new DeletedBadgetypeDto
            {
                Id = badgetype.Id,
                Title = badgetype.Title,
            };

            // Can also just send empty Ok() back instead
            return Ok(deletedBadgetypeDto);
        }
    }
}

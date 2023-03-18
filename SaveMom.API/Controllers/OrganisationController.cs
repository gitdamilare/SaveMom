using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos;
using SaveMom.Services;
using System.Net;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;
        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<OrganisationDto>>> Get()
        {
            var organisation =  await _organisationService.Get();
            return new ApiResponse<List<OrganisationDto>>(true, (int)HttpStatusCode.OK, organisation);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<ApiResponse<OrganisationDto>>> Get(string id)
        {
            var organisation = await _organisationService.Get(id);
            if (organisation == null)
            {
                return NotFound();
            }
            return new ApiResponse<OrganisationDto>(true, (int)HttpStatusCode.OK, organisation);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Post([FromBody] OrganisationDto inputDto)
        {
            var result = await _organisationService.Create(inputDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] OrganisationDto inputDto)
        {
            var organisation = await _organisationService.Get(id);

            if (organisation == null)
                return NotFound();

            inputDto.Id = organisation.Id;

            await _organisationService.Update(id, inputDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var organisation = await _organisationService.Get(id);

            if (organisation == null)
                return NotFound();

            await _organisationService.Remove(id);

            return NoContent();
        }
    }
}

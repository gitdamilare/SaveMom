using System.Net;
using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos;
using SaveMom.Services;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalExaminationController : ControllerBase
    {
        private readonly IPhysicalExaminationService _physicalExaminationService;

        public PhysicalExaminationController(IPhysicalExaminationService physicalExaminationService)
        {
            _physicalExaminationService = physicalExaminationService;
        }

        // GET: api/<PhysicalExaminationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PhysicalExaminationResponse>>> Get(string id)
        {
            var result = await _physicalExaminationService.Get(id);
            if (!result.IsSuccess)
            {
                return new ApiResponse<PhysicalExaminationResponse>(false, (int)HttpStatusCode.BadRequest, null, result.Errors);
            }
            return new ApiResponse<PhysicalExaminationResponse>(true, (int)HttpStatusCode.OK, result.Data);
        }

        // GET api/<PhysicalExaminationController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PhysicalExaminationResponse>>>> Get()
        {
            var result = await _physicalExaminationService.Get();
            return new ApiResponse<List<PhysicalExaminationResponse>>(true, (int)HttpStatusCode.OK, result.Data);
        }

        [HttpGet("getbypatientid/{patientId}")]
        public async Task<ActionResult<ApiResponse<List<PhysicalExaminationResponse>>>> GetPhysicalExamination(string patientId)
        {
            var result = await _physicalExaminationService.GetByPatientId(patientId);
            if (!result.IsSuccess)
            {
                return new ApiResponse<List<PhysicalExaminationResponse>>(false, (int)HttpStatusCode.BadRequest, null, result.Errors);
            }
            return new ApiResponse<List<PhysicalExaminationResponse>>(true, (int)HttpStatusCode.OK, result.Data);
        }

        // POST api/<PhysicalExaminationController>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<PhysicalExaminationResponse>>>  Post([FromBody] PhysicalExaminationRequest inputDto)
        {
            var result = await _physicalExaminationService.Create(inputDto);
            if (!result.IsSuccess)
            {
                //return BadRequest(apiResponse);
                return new ApiResponse<PhysicalExaminationResponse>(false, (int)HttpStatusCode.BadRequest, null, result.Errors);
            }
            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }

        // PUT api/<PhysicalExaminationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhysicalExaminationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

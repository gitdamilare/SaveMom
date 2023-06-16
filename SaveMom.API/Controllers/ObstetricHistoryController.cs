using System.Net;
using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos;
using SaveMom.Services;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObstetricHistoryController : ControllerBase
    {
        private readonly IObstetricHistoryService _obstetricHistoryService;
        public ObstetricHistoryController(IObstetricHistoryService obstetricHistoryService)
        {
            _obstetricHistoryService = obstetricHistoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ObstetricHistoryResponse>>> Get(string id)
        {
            var result = await _obstetricHistoryService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return new ApiResponse<ObstetricHistoryResponse>(true, (int)HttpStatusCode.OK, result);
        }

        [HttpGet("getbypatientid/{patientId}")]
        public async Task<ActionResult<ApiResponse<List<ObstetricHistoryResponse>>>> GetPatientObstetricHistory(string patientId)
        {
            var result = await _obstetricHistoryService.GetByPatientId(patientId);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return new ApiResponse<List<ObstetricHistoryResponse>>(true, (int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObstetricHistoryRequest inputDto)
        {
            var result = await _obstetricHistoryService.Create(inputDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ApiResponse<List<ObstetricHistoryResponse>>> Get()
        {
            var obstetricHistories = await _obstetricHistoryService.Get();
            return new ApiResponse<List<ObstetricHistoryResponse>>(true, (int)HttpStatusCode.OK, obstetricHistories);
        }
    }
}

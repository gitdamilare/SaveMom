using System.Net;
using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos;
using SaveMom.Services;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : Controller
    {
        private readonly IMedicalHistoryService _medicalHistoryService;

        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<MedicalHistoryResponse>>> Get()
        {
            var result = await _medicalHistoryService.Get();
            return new ApiResponse<List<MedicalHistoryResponse>>(true, (int)HttpStatusCode.OK, result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<MedicalHistoryResponse>>> Get(string id)
        {
            var result = await _medicalHistoryService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return new ApiResponse<MedicalHistoryResponse>(true, (int)HttpStatusCode.OK, result);
        }

        [HttpGet("getbypatientid/{patientId}")]
        public async Task<ActionResult<ApiResponse<MedicalHistoryResponse>>> GetPatientMedicalHistory(string patientId)
        {
            var result = await _medicalHistoryService.GetByPatientId(patientId);
            if (result == null)
            {
                return NotFound();
            }
            return new ApiResponse<MedicalHistoryResponse>(true, (int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<MedicalHistoryResponse>>> Post([FromBody] MedicalHistoryRequest inputDto)
        {
            var result = await _medicalHistoryService.Create(inputDto);
            if (!result.IsSuccess)
            {
                //return BadRequest(apiResponse);
                return new ApiResponse<MedicalHistoryResponse>(false, (int)HttpStatusCode.BadRequest, null, result.Errors);
            }
            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }
    }
}

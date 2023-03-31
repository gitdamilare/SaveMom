using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Services;
using System.Net;
using SaveMom.Contracts.Dtos.Antenatal;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PatientResponseDto>>> Get(string id)
        {
            var patient = await _patientService.Get(id);
            if (patient == null)
            {
                return NotFound();
            }
            return new ApiResponse<PatientResponseDto>(true, (int)HttpStatusCode.OK, patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientRequestDto inputDto)
        {
            var result = await _patientService.Create(inputDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ApiResponse<List<PatientResponseDto>>> Get()
        {
            var patients = await _patientService.Get();
            return new ApiResponse<List<PatientResponseDto>>(true, (int)HttpStatusCode.OK, patients);
        }
    }
}

using SaveMom.Contracts.Dtos;
using SaveMom.Contracts.Dtos.Antenatal;

namespace SaveMom.Services
{
    public interface IPatientService
    {
        Task<List<PatientResponseDto>> Get();
        Task<PatientResponseDto> Get(string id);
        Task<CreatePatientResponseDto> Create(PatientRequestDto organisation);
        Task Remove(string id);
        //Task Update(string id, OrganisationDto organisation);
    }
}

using Mapster;
using MongoDB.Driver;
using SaveMom.Contracts.Dtos.Antenatal;
using SaveMom.Domain.Antenatal;
using SaveMom.Domain.Data;

namespace SaveMom.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMongoCollection<Patient> _patientCollection;

        public PatientService(IDbContext<Patient> dbContext)
        {
            _patientCollection = dbContext.Collection;
        }

        public async Task<CreatePatientResponseDto> Create(PatientRequestDto patientDto)
        {
            var patient = patientDto.Adapt<Patient>();
            await _patientCollection.InsertOneAsync(patient);
            return new CreatePatientResponseDto
            {
                Id = patient.Id,
            };
        }

        public async Task<List<PatientResponseDto>> Get()
        {
            var result = await _patientCollection.Find(_ => true)
                .SortByDescending(p => p.CreatedDate)
                .ToListAsync();
            return result.Adapt<List<PatientResponseDto>>();
        }

        public async Task<PatientResponseDto> Get(string id)
        {
            var result = await _patientCollection.Find(xx => xx.Id == id).FirstOrDefaultAsync();
            return result.Adapt<PatientResponseDto>();
        }

        public async Task Remove(string id) => await _patientCollection.DeleteOneAsync(xx => xx.Id == id);
    }
}

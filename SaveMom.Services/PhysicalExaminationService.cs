using Mapster;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SaveMom.Contracts.Dtos;
using SaveMom.Domain;
using SaveMom.Domain.Data;

namespace SaveMom.Services
{
    public class PhysicalExaminationService : IPhysicalExaminationService
    {
        private readonly ILogger _logger;
        private readonly IMongoCollection<PhysicalExamination> _physicalExaminationCollection;
        public PhysicalExaminationService(ILogger<PhysicalExaminationService> logger, IDbContext<PhysicalExamination> dbContext)
        {
            _logger = logger;
            _physicalExaminationCollection = dbContext.Collection;
        }

        public async Task<(List<PhysicalExaminationResponse> Data, bool IsSuccess, List<string> Errors)> Get()
        {
            var physicalExaminations = await _physicalExaminationCollection
                .Find(_ => true)
                .SortByDescending(xx => xx.CreatedBy)
                .ToListAsync();
            var data = physicalExaminations.Adapt<List<PhysicalExaminationResponse>>();
            return (data, true, new List<string>());
        }

        public async Task<(PhysicalExaminationResponse Data, bool IsSuccess, List<string> Errors)> Get(string id)
        {
            var physicalExamination = await _physicalExaminationCollection
                .Find(xx => xx.Id == id)
                .FirstOrDefaultAsync();

            var result = physicalExamination.Adapt<PhysicalExaminationResponse>();
            return (result, true, new List<string>());
        }

        public async Task<(List<PhysicalExaminationResponse> Data, bool IsSuccess, List<string> Errors)> GetByPatientId(string patientId)
        {
            //TODO: Check if PatientId exist
            var physicalExamination = await _physicalExaminationCollection
                .Find(xx => xx.PatientId == patientId)
                .SortByDescending(xx => xx.CreatedBy)
                .ToListAsync();

            var result = physicalExamination.Adapt<List<PhysicalExaminationResponse>>();
            return (result, true, new List<string>());
        }

        public async Task<(PhysicalExaminationResponse Data, bool IsSuccess, List<string> Errors)> Create(PhysicalExaminationRequest inputData)
        {
            //TODO: Check if the Patient exists with {{inputData.PatientId}} 
            var physicalExamination = inputData.Adapt<PhysicalExamination>();
            await _physicalExaminationCollection.InsertOneAsync(physicalExamination);
            var result = physicalExamination.Adapt<PhysicalExaminationResponse>();
            return (result, true, new List<string>());
        }

        public async Task<(bool IsSuccess, List<string> Errors)> Update(string id, PhysicalExaminationRequest inputData)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, List<string> Errors)> Remove(string id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public PhysicalExamination GetParams(params string[] names)
        {
            throw new NotImplementedException();
        }
    }
}

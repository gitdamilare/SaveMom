using Mapster;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SaveMom.Contracts.Dtos;
using SaveMom.Domain;
using SaveMom.Domain.Antenatal;
using SaveMom.Domain.Data;

namespace SaveMom.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly ILogger _logger;
        private readonly IMongoCollection<MedicalHistory> _medicaHistoryCollection;

        public MedicalHistoryService(ILogger<MedicalHistoryService> logger, IDbContext<MedicalHistory> dbContext)
        {
            _logger = logger;
            _medicaHistoryCollection = dbContext.Collection;
        }

        public async Task<(List<MedicalHistoryResponse> Data, bool IsSuccess, List<string> Errors)> Get()
        {
            var medicalHistories = await _medicaHistoryCollection
                .Find(_ => true)
                .SortByDescending(xx => xx.CreatedBy)
                .ToListAsync();
            var data = medicalHistories.Adapt<List<MedicalHistoryResponse>>();
            return (data, true, new List<string>());
        }

        public async Task<MedicalHistoryResponse> Get(string id)
        {
            var medicalHistory = await _medicaHistoryCollection
                .Find(xx => xx.Id == id)
                .FirstOrDefaultAsync();

            var result = medicalHistory.Adapt<MedicalHistoryResponse>();
            return result;
        }

        public async Task<MedicalHistoryResponse> GetByPatientId(string patientId)
        {
            var medicalHistory = await _medicaHistoryCollection
                .Find(xx => xx.PatientId == patientId)
                .SortByDescending(xx => xx.CreatedBy)
                .FirstOrDefaultAsync();

            var result = medicalHistory.Adapt<MedicalHistoryResponse>();
            return result;
        }

        //TODO: Check if the Patient exists with {{inputData.PatientId}} 
        public async Task<(MedicalHistoryResponse Data, bool IsSuccess, List<string> Errors)> Create(MedicalHistoryRequest inputData)
        { 
            var medicalRecordExist = await _medicaHistoryCollection
                .Find(xx => xx.PatientId == inputData.PatientId).AnyAsync();

            if (medicalRecordExist)
            {
                //TODO: How many medical record can a patient have - if its one then check if a medical history already exist
                _logger.LogError("Cannot create new medical history for patientId {patientId} because medical history already exist", inputData.PatientId);
                return (null, false, new List<string> { "MedicalHistory already exist" });
            }

            var medicalHistory = inputData.Adapt<MedicalHistory>();
            await _medicaHistoryCollection.InsertOneAsync(medicalHistory);
            var result = medicalHistory.Adapt<MedicalHistoryResponse>();
            return (result, true, new List<string>());
        }

        public async Task Update(string id, MedicalHistoryRequest inputData)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task Remove(string id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }

}

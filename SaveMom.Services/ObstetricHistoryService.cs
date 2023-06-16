using Mapster;
using MongoDB.Driver;
using SaveMom.Contracts.Dtos;
using SaveMom.Domain.Data;
using SaveMom.Domain.Prenatal;

namespace SaveMom.Services
{
    public class ObstetricHistoryService : IObstetricHistoryService
    {
        private readonly IMongoCollection<ObstetricHistory> _obstetricHistoryCollection;

        public ObstetricHistoryService(IDbContext<ObstetricHistory> dbContext)
        {
            _obstetricHistoryCollection = dbContext.Collection;
        }

        public async Task<List<ObstetricHistoryResponse>> Get()
        {
            var obstetricHistories = await _obstetricHistoryCollection.Find(_ => true)
                .SortByDescending(xx => xx.CreatedBy)
                .ToListAsync();
            var result = obstetricHistories.Adapt<List<ObstetricHistoryResponse>>();
            return result;
        }

        public async Task<ObstetricHistoryResponse> Get(string id)
        {
            var obstetricHistory = await _obstetricHistoryCollection.Find(xx => xx.Id == id)
                .FirstOrDefaultAsync();

            var result = obstetricHistory.Adapt<ObstetricHistoryResponse>();
            return result;
        }

        public async Task<List<ObstetricHistoryResponse>> GetByPatientId(string patientId)
        {
            var obstetricHistory = await _obstetricHistoryCollection
                .Find(xx => xx.PatientId == patientId)
                .SortByDescending(xx => xx.CreatedBy)
                .ToListAsync(); 
            
            var result = obstetricHistory.Adapt<List<ObstetricHistoryResponse>>();
            return result;
        }

        public async Task<ObstetricHistoryResponse> Create(ObstetricHistoryRequest inputData)
        {
            var obstetricHistory = inputData.Adapt<ObstetricHistory>();

            //TODO: Check if the Patient exists with {{inputData.PatientId}} 
            await _obstetricHistoryCollection.InsertOneAsync(obstetricHistory);

            var result = obstetricHistory.Adapt<ObstetricHistoryResponse>();
            return result;
        }

        public async Task Update(string id, ObstetricHistoryRequest inputData)
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

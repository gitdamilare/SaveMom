using SaveMom.Contracts.Dtos;

namespace SaveMom.Services
{
    public interface IObstetricHistoryService
    {
        Task<List<ObstetricHistoryResponse>> Get();
        Task<ObstetricHistoryResponse> Get(string id);
        Task<List<ObstetricHistoryResponse>> GetByPatientId(string patientId);
        Task<ObstetricHistoryResponse> Create(ObstetricHistoryRequest inputData);
        Task Update(string id, ObstetricHistoryRequest inputData);
        Task Remove(string id);
    }
}
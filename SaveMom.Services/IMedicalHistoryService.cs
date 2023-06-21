using SaveMom.Contracts.Dtos;

namespace SaveMom.Services
{
    public interface IMedicalHistoryService
    {
        Task<(List<MedicalHistoryResponse> Data, bool IsSuccess, List<string> Errors)> Get();
        Task<MedicalHistoryResponse> Get(string id);
        Task<MedicalHistoryResponse> GetByPatientId(string patientId);
        Task<(MedicalHistoryResponse Data, bool IsSuccess, List<string> Errors)> Create(MedicalHistoryRequest inputData);
        Task Update(string id, MedicalHistoryRequest inputData);
        Task Remove(string id);
    }
}

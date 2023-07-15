using SaveMom.Contracts.Dtos;
using SaveMom.Domain;

namespace SaveMom.Services;

public interface IPhysicalExaminationService
{
    Task<(List<PhysicalExaminationResponse> Data, bool IsSuccess, List<string> Errors)> Get();
    Task<(PhysicalExaminationResponse Data, bool IsSuccess, List<string> Errors)> Get(string id);
    Task<(List<PhysicalExaminationResponse> Data, bool IsSuccess, List<string> Errors)> GetByPatientId(string patientId);
    Task<(PhysicalExaminationResponse Data, bool IsSuccess, List<string> Errors)> Create(PhysicalExaminationRequest inputData);
    Task<(bool IsSuccess, List<string> Errors)> Update(string id, PhysicalExaminationRequest inputData);
    Task<(bool IsSuccess, List<string> Errors)> Remove(string id);
    PhysicalExamination GetParams(params string[] names);
}
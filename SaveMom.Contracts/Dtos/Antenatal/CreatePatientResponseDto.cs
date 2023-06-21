
namespace SaveMom.Contracts.Dtos.Antenatal
{
    public record CreatePatientResponseDto : BaseServiceResponse
    {
        public string? Id { get; set; }
    }
}

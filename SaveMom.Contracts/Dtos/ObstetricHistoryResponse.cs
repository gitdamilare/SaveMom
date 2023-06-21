using static SaveMom.Contracts.AppEnum;

namespace SaveMom.Contracts.Dtos
{
    public record ObstetricHistoryResponse : BaseServiceResponse
    {
        public string? Id { get; set; }

        public string? PatientId { get; set; }

        public DateTime? BirthYear { get; set; }

        public Gender Gender { get; set; }

        public int Gestation { get; set; }

        public int LabourLength { get; set; }

        public string? BirthPlace { get; set; }

        public BirthType BirthType { get; set; }

        public string? Comment { get; set; }
    }
}

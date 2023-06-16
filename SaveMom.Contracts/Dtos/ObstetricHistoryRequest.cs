namespace SaveMom.Contracts.Dtos
{
    public class ObstetricHistoryRequest
    {
        public string? PatientId { get; set; }

        public DateTime? BirthYear { get; set; }

        public Contracts.AppEnum.Gender Gender { get; set; }

        public int Gestation { get; set; }

        public int LabourLength { get; set; }

        public string? BirthPlace { get; set; }

        public Contracts.AppEnum.BirthType BirthType { get; set; }

        public string? Comment { get; set; }
    }
}

using static SaveMom.Contracts.Dtos.AppEnum;

namespace SaveMom.Contracts.Dtos.Antenatal
{
    public class PatientResponseDto : BaseServiceResponse
    {
        public string? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? DOB { get; set; }

        public string? HospitalPHCNO { get; set; }

        public string? SpouseName { get; set; }

        public AddressDto? Address { get; set; }

        public string? ContactNumber { get; set; }

        public MartialStatus MaritalStatus { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public string[]? Allergies { get; set; }
    }
}

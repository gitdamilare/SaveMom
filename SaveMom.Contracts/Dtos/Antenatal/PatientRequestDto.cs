using System.ComponentModel.DataAnnotations;
using static SaveMom.Contracts.Dtos.AppEnum;

namespace SaveMom.Contracts.Dtos.Antenatal
{
    public class PatientRequestDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? DOB { get; set; }

        //TODO : Generate HospitalPHCNO from PatientID
        public string? HospitalPHCNO => Guid.NewGuid().ToString();

        public string? SpouseName { get; set; }

        public AddressDto? Address { get; set; }

        public string? ContactNumber { get; set; }

        [Required]
        public MartialStatus MaritalStatus { get; set; }

        [Required]
        public EducationLevel EducationLevel { get; set; }

        public string[]? Allergies { get; set; }
    }
}

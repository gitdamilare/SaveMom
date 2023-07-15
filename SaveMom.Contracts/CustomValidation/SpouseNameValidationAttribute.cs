using SaveMom.Contracts.Dtos.Antenatal;
using System.ComponentModel.DataAnnotations;

namespace SaveMom.Contracts.CustomValidation
{
    internal class SpouseNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var patientRequest = validationContext.ObjectInstance as PatientRequestDto;

            if(patientRequest?.MaritalStatus == Dtos.AppEnum.MartialStatus.Married
                && string.IsNullOrEmpty(patientRequest?.SpouseInfo?.Name))
            {
                return new ValidationResult("SpouseName cannot be null");
            }
            return ValidationResult.Success;
        }
    }
}

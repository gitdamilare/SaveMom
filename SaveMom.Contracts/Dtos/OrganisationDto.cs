namespace SaveMom.Contracts.Dtos
{
    public class OrganisationDto
    {
        public string? Id { get; set; }

        public string RegistrationNumber { get; set; } = string.Empty;

        public OrganisationTypeDto Type { get; set; }

        public string Name { get; set; } = string.Empty;

        public AddressDto? Address { get; set; }

        public ContactInfoDto? ContactPerson { get; set; }

        public bool IsActive { get; set; }
    }
}

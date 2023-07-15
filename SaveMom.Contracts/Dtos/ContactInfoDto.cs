namespace SaveMom.Contracts.Dtos
{
    public class ContactInfoDto
    {
        public string? Name { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
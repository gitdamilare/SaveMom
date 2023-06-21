namespace SaveMom.Contracts.Dtos.Identity
{
    public record RegistrationPageDataResponse : BaseServiceResponse
    {
        public List<RegistrationPageData>? UserRoles { get; set; }

        public List<RegistrationPageData>? Organisations { get; set; }
    }

    public record RegistrationPageData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}

namespace SaveMom.Contracts.Dtos.Identity
{
    public class RegistrationPageDataResponse : BaseServiceResponse
    {
        public List<RegistrationPageData>? UserRoles { get; set; }

        public List<RegistrationPageData>? Organisations { get; set; }
    }

    public class RegistrationPageData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}

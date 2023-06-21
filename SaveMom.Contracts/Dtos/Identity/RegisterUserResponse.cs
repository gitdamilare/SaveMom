namespace SaveMom.Contracts.Dtos.Identity
{
    public record RegisterUserResponse : BaseServiceResponse
    {
        public string? Email { get; set; }
    }
}

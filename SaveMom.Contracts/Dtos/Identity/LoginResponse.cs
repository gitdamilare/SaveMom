namespace SaveMom.Contracts.Dtos.Identity
{
    public record LoginResponse : BaseServiceResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

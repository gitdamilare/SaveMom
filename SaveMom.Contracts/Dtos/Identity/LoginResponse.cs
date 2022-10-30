namespace SaveMom.Contracts.Dtos.Identity
{
    public class LoginResponse : BaseServiceResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

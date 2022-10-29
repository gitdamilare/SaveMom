namespace SaveMom.IdentityApp.Dtos
{
    public class LoginResponse : BaseServiceResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

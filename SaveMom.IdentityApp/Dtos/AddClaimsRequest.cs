namespace SaveMom.IdentityApp.Dtos
{
    public class AddClaimsRequest
    {
        public string? Email { get; set; }

        public UserClaimRequest[] Claims { get; set; }
    }

    public class UserClaimRequest
    {
        public string? Claim { get; set; }

        public string? Value { get; set; }
    }
}

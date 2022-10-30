namespace SaveMom.Contracts.Dtos.Identity
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

namespace SaveMom.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty ;
        public string Password { get; set; } = string.Empty ;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public Organisation? Organisation { get; set; }
        public Address? Address { get; set; }
        public string UploadDocument { get; set; } = string.Empty;
    }
}

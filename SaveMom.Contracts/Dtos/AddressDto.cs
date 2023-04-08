namespace SaveMom.Contracts.Dtos
{
    public class AddressDto
    {
        public string GeopoliticalRegion { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string LocalGovernment { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public string Country => "Nigeria";
    }
}
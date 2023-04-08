using MongoDB.Bson.Serialization.Attributes;

namespace SaveMom.Domain
{
    public class Address
    {
        [BsonElement("GeopoliticalRegion")]
        public string GeopoliticalRegion { get; set; } = string.Empty;
        
        [BsonElement("State")]
        public string State { get; set; } = string.Empty;

        [BsonElement("LocalGovernment")]
        public string LocalGovernment { get; set; } = string.Empty;

        [BsonElement("Ward")] 
        public string Ward { get; set; } = string.Empty;

        [BsonElement("Street")]
        public string Street { get; set; } = string.Empty;

        [BsonElement("City")]
        public string City { get; set; } = string.Empty;

        [BsonElement("LandMark")]
        public string LandMark { get; set; } = string.Empty;

        [BsonElement("Country")]
        public string Country => "Nigeria";
    }
}

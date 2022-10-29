using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SaveMom.Domain
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

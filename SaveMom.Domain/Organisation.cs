using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace SaveMom.Domain
{
    [CollectionName("Organisations")]
    public class Organisation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [BsonElement("Type")]
        public OrganisationType Type { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty ;

        [BsonElement("Address")]
        public Address? Address { get; set; }

        [BsonElement("ContactPerson")]
        public ContactInfo? ContactPerson { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
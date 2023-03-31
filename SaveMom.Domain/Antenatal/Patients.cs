using static SaveMom.Contracts.Dtos.AppEnum;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace SaveMom.Domain.Antenatal
{
    [CollectionName("Patients")]
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("FirstName")]
        public string? FirstName { get; set; }

        [BsonElement("LastName")]
        public string? LastName { get; set; }

        [BsonElement("DOB")]
        public DateTime? DateOfBirth { get; set; }

        [BsonElement("HospitalPHCNO")]
        public string? HospitalPHCNO { get; set; }

        [BsonElement("ContactNumber")]
        public string? ContactNumber { get; set; }

        [BsonElement("Spouse")]
        public ContactInfo? Spouse { get; set; }

        [BsonElement("Address")]
        public Address? Address { get; set; }

        [BsonElement("MaritalStatus")]
        public MartialStatus MaritalStatus { get; set; }

        [BsonElement("EducationLevel")]
        public EducationLevel EducationLevel { get; set; }

        [BsonElement("Allergies")]
        public string[]? Allergies { get; set; }
    }
}

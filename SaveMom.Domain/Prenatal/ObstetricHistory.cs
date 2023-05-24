using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using static SaveMom.Domain.AppEnum;

namespace SaveMom.Domain.Prenatal
{
    [CollectionName("ObstetricHistory")]
    public class ObstetricHistory : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("PatientId")]
        public string? PatientId { get; set; }

        [BsonElement("BirthYear")]
        public DateTime? BirthYear { get; set; }

        [BsonElement("Gender")]
        public Gender Gender { get; set; }

        [BsonElement("Gestation")]
        public int Gestation { get; set; }

        [BsonElement("LabourLength")]
        public int LabourLength { get; set; }

        [BsonElement("BirthPlace")]
        public string? BirthPlace { get; set; }

        [BsonElement("BirthType")]
        public BirthType BirthType { get; set; }

        [BsonElement("Comment")]
        public string? Comment { get; set; }
    }
}

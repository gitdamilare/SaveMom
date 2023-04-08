using MongoDB.Bson.Serialization.Attributes;

namespace SaveMom.Domain
{
    public abstract class BaseEntity
    {
        [BsonElement("CreatedDate")]
        public DateTime? CreatedDate => DateTime.Now;

        [BsonElement("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; } = DateTime.MinValue;

        [BsonElement("CreatedBy")]
        public string? CreatedBy { get; set; }

        [BsonElement("ModifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}

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
        public string? CreatedBy { get; set; } = "ca2bb416-ed5e-43dc-b389-9fb85c0a6a0d";

        [BsonElement("ModifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}

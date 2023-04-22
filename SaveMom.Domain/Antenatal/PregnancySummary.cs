using MongoDB.Bson.Serialization.Attributes;

namespace SaveMom.Domain.Antenatal
{
    public class PregnancySummary
    {
        [BsonElement("LastMenstruationDate")]
        public DateTime? LastMenstruationDate { get; set; }

        [BsonElement("ExpectedDeliveryDate")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [BsonElement("Gravida")]
        public int Gravida { get; set; }

        [BsonElement("Term")]
        public int Term { get; set; }

        [BsonElement("PerTerm")]
        public int PerTerm { get; set; }

        [BsonElement("LivingNo")]
        public int? LivingNo { get; set; }

        [BsonElement("PregnancyLoss")]
        public PregnancyLoss? PregnancyLoss { get; set; }
    }
}

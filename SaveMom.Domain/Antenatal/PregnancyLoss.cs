using MongoDB.Bson.Serialization.Attributes;

namespace SaveMom.Domain.Antenatal
{
    public class PregnancyLoss
    {
        [BsonElement("AbortionNo")]
        public int AbortionNo { get; set; }

        [BsonElement("EctopicNo")]
        public int EctopicNo { get; set; }

        [BsonElement("StillBirthNo")]
        public int StillBirthNo { get; set; }
    }
}

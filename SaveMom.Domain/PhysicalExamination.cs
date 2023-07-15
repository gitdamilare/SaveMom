using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace SaveMom.Domain
{
    [CollectionName("PhysicalExaminations")]
    public class PhysicalExamination : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? PatientId { get; set; }
        public int Weight { get; set; }
        public int BloodPressure { get; set; }
        public int Pulse { get; set; }
        public string PhysicalAbnormality { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public Dictionary<string, bool> TestResult { get; set; } = new();
        public Dictionary<string, bool> HealthTopicCovered { get; set; } = new();
        public List<LabTest> LabTest { get; set; } = new();
        public Dictionary<string, (bool requested, string result)> JsonLabTest { get; set; } = new();
    }

    public class LabTest
    {
        public string Key { get; set; } = string.Empty;
        public bool Requested { get; set; }
        public string Result { get; set; } = string.Empty;
    }

}

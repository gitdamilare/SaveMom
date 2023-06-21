using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace SaveMom.Domain
{
    [CollectionName("MedicalHistory")]
    public class MedicalHistory : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("PatientId")]
        public string? PatientId { get; set; }

        [BsonElement("BabyLoss")]
        public bool BabyLoss { get; set; }

        [BsonElement("SpontaneousAbortion")]
        public bool SpontaneousAbortion { get; set; }

        [BsonElement("UnderWeightBaby")]
        public bool UnderWeightBaby { get; set; }

        [BsonElement("ExcessWeightBaby")]
        public bool ExcessWeightBaby { get; set; }

        [BsonElement("LastPregnancy")]
        public bool LastPregnancy { get; set; }

        [BsonElement("PreviousSurgery")]
        public bool PreviousSurgery { get; set; }

        [BsonElement("MultiplePregnancy")]
        public bool MultiplePregnancy { get; set; }
        
        [BsonElement("UnderAge")]
        public bool UnderAge { get; set; }
        
        [BsonElement("OverAge")]
        public bool OverAge { get; set; }

        [BsonElement("RhesusNegative")]
        public bool RhesusNegative { get; set; }

        [BsonElement("VaginalBleeding")]
        public bool VaginalBleeding { get; set; }

        [BsonElement("PelvicMass")]
        public bool PelvicMass { get; set; }

        [BsonElement("DiastolicBP")]
        public bool DiastolicBP { get; set; }

        [BsonElement("DiabetesMellitus")]
        public bool DiabetesMellitus { get; set; }

        [BsonElement("RenalDisease")]
        public bool RenalDisease { get; set; }

        [BsonElement("CardiacDisease")]
        public bool CardiacDisease { get; set; }

        [BsonElement("SickleCellDisease")]
        public bool SickleCellDisease { get; set; }

        [BsonElement("HIVPositive")]
        public bool HIVPositive { get; set; }

        [BsonElement("OtherMedicalCondition")]
        public string OtherMedicalCondition { get; set; } = string.Empty;

    }
}

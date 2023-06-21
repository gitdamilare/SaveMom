namespace SaveMom.Contracts.Dtos
{
    public class MedicalHistoryRequest
    {
        public string? PatientId { get; set; }

        public bool BabyLoss { get; set; }

        public bool SpontaneousAbortion { get; set; }

        public bool UnderWeightBaby { get; set; }

        public bool ExcessWeightBaby { get; set; }

        public bool LastPregnancy { get; set; }

        public bool PreviousSurgery { get; set; }

        public bool MultiplePregnancy { get; set; }

        public bool UnderAge { get; set; }

        public bool OverAge { get; set; }

        public bool RhesusNegative { get; set; }

        public bool VaginalBleeding { get; set; }

        public bool PelvicMass { get; set; }

        public bool DiastolicBP { get; set; }

        public bool DiabetesMellitus { get; set; }

        public bool RenalDisease { get; set; }

        public bool CardiacDisease { get; set; }

        public bool SickleCellDisease { get; set; }

        public bool HIVPositive { get; set; }

        public string OtherMedicalCondition { get; set; } = string.Empty;
    }
}

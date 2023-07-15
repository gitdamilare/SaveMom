namespace SaveMom.Contracts.Dtos
{
    public class PhysicalExaminationResponse
    {
        public string? Id { get; set; }

        public string? PatientId { get; set; }
        public int Weight { get; set; }
        public int BloodPressure { get; set; }
        public int Pulse { get; set; }
        public string PhysicalAbnormality { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public Dictionary<string, bool> TestResult { get; set; } = new();
        public Dictionary<string, bool> HealthTopicCovered { get; set; } = new();
        public List<LabTestDto> LabTest { get; set; } = new();
    }
}

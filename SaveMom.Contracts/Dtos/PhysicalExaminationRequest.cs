namespace SaveMom.Contracts.Dtos
{
    public class PhysicalExaminationRequest
    {
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

    public class LabTestDto
    {
        public string Key { get; set; } = string.Empty;
        public bool Requested { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}

namespace SaveMom.Contracts.Dtos
{
    public record BaseServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}

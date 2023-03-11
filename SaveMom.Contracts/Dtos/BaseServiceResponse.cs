namespace SaveMom.Contracts.Dtos
{
    public class BaseServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}

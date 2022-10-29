namespace SaveMom.IdentityApp.Dtos
{
    public class ApiResponse<T> where T : class
    {
        public string Version => "1.0.0";

        public bool Success { get; set; } = true;

        public int StatusCode { get; set; }

        public object? ErrorMessage { get; set; }

        public T? Result { get; set; }

        public ApiResponse(bool success, int statusCode, T? result, object? errorMessage = null)
        {
            Success = success;
            StatusCode = statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public ApiResponse() { }
    }
}

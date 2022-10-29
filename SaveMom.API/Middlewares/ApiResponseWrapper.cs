using Newtonsoft.Json;
using System.Net;

namespace SaveMom.API.Middlewares
{
    public class ApiResponseWrapper
    {
        private readonly RequestDelegate _next;

        public ApiResponseWrapper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/swagger"))
            {
                var currentBody = context.Request.Body;
                using (var memoryStream = new MemoryStream())
                {
                    //set the current response to the memorystream.
                    context.Response.Body = memoryStream;

                    await _next(context);

                    //reset the body 
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using(var streamReader = new StreamReader(memoryStream))
                    {
                        var readToEnd = streamReader.ReadToEnd();
                        var objResult = JsonConvert.DeserializeObject(readToEnd);
                        context.Response.Body = currentBody;

                        var result = ApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, null);
                        try
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                            return;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                }
            }

            await _next(context);
        }

    }

    public static class ApiResponseWrapperExtensions
    {
        public static IApplicationBuilder UseApiResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseWrapper>();
        }
    }

    public class ApiResponse
    {
        public string Version => "1.0.0";

        public int StatusCode { get; set; }

        public string RequestId { get; }

        public string? ErrorMessage { get; set; }

        public object? Result { get; set; }

        protected ApiResponse(HttpStatusCode statusCode, object? result = null, string? errorMessage = null)
        {
            RequestId = Guid.NewGuid().ToString();
            StatusCode = (int)statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse Create(HttpStatusCode statusCode, object? result = null, string? errorMessage = null)
        {
            return new ApiResponse(statusCode, result, errorMessage);
        }
    }
}

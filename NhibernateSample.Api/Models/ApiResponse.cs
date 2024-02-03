namespace NHibernateSample.Api.Models;
public class ApiResponse<T>
{
    public ApiResponse(T data)
    {
        Data = data;
        Success = true;
    }

    public ApiResponse(string error, ApiResponseCode code)
    {
        Error = error;
        Code = code;
        Success = false;
    }

    public bool Success { get; }
    public T Data { get; }
    public string Error { get; }
    public ApiResponseCode Code { get; }
}

// ApiResponseCode.cs
public enum ApiResponseCode
{
    NotFound,
    ServerError,
    // Add more as needed
}

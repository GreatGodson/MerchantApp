namespace MerchantApp.Application.Common;
public record ApiResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public string StatusCode { get; set; } = ResponseCodes.Ok;
    public string Message { get; set; } = ResponseMessages.Ok;
    public T? Data { get; set; }
    public object? MetaData { get; set; }

    public static ApiResponse<T> Success(T data, string message = ResponseMessages.Ok, object? metaData = null)
    {
        return new ApiResponse<T>
        {
            StatusCode = ResponseCodes.Ok,
            IsSuccess = true,
            Message = message,
            Data = data,
            MetaData = metaData
        };
    }

    public static ApiResponse<T> NotFound(string message, object? metaData = null)
    {
        return new ApiResponse<T>
        {
            StatusCode = ResponseCodes.NotFound,
            IsSuccess = false,
            Message = message,
            Data = default,
            MetaData = metaData
        };
    }

    public static ApiResponse<T> BadRequest(string message, object? metaData = null)
    {
        return new ApiResponse<T>
        {
            StatusCode = ResponseCodes.BadRequest,
            IsSuccess = false,
            Message = message,
            Data = default,
            MetaData = metaData
        };
    }

    public static ApiResponse<T> Unauthorized(string message, object? metaData = null)
    {
        return new ApiResponse<T>
        {
            StatusCode = ResponseCodes.Unauthorized,
            IsSuccess = false,
            Message = message,
            Data = default,
            MetaData = metaData
        };
    }
}


public struct ResponseCodes
{
    public const string Ok = "200";
    public const string InternalServer = "500";
    public const string BadRequest = "400";
    public const string Unauthorized = "401";
    public const string NotFound = "404";
}


public struct ResponseMessages
{
    public const string Ok = "Successful";
    public const string InternalServer = "Something went wrong";
    public const string Unauthorized = "Unauthorized";
    public const string ValidationError = "One or more validation errors occurred";
}
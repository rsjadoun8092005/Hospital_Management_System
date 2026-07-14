
namespace HMS.Core.Common
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static ResponseModel<T> SuccessResponse(T data, string message = "Success")
        {
            return new ResponseModel<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel<T> FailureResponse(string message, List<string>? errors = null)
        {
            return new ResponseModel<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}

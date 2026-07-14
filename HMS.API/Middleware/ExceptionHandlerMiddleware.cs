namespace HMS.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = ResponseModel<string>.FailureResponse(error.Message);

                switch (error)
                {
                    case ValidationException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        responseModel.Message = "Validation Failed";

                        var errorList = new List<string>();
                        foreach (var err in e.Errors)
                        {
                            errorList.AddRange(err.Value);
                        }
                        responseModel.Errors = errorList;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}

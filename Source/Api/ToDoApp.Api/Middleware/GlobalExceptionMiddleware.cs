using Shared.Common.Constants;
using Shared.Common.Exceptions;
using Shared.Common.Models;
using System.Net;

namespace ToDoApp.Api.Middleware
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorCode = ErrorCodes.InternalError;
            var message = "An unexpected error occurred.";

            if (exception is ValidationException)
            {
                statusCode = HttpStatusCode.BadRequest;
                errorCode = ErrorCodes.ValidationFailed;
                message = exception.Message;
            }
            else if (exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                errorCode = ErrorCodes.NotFound;
                message = exception.Message;
            }

            var response = new ApiResponse<object>(
                false,
                $"{errorCode}: {message}",
                null
            );

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}

using Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
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
            catch (Exception error)
            {

                await HandleException(context, error);
            }
        }

        private async Task HandleException(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType= "application/json";

            response.StatusCode = error switch
            {
                BadRequestException e => (int)HttpStatusCode.BadRequest,
                NotFoundException e => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = error.Message;

            if(error.InnerException != null) message = error.InnerException.Message;

            var result = JsonSerializer.Serialize(new {
            
                message=message,
                exception = error?.StackTrace
            });

            _logger.LogError(string.Join(" | ", $"STATUS CODE : {response.StatusCode} ", $"ERROR MESSAGE : {error?.Message}", $"EXCEPTION : {error?.StackTrace}"));
            await response.WriteAsync(result);
        }
    }
}

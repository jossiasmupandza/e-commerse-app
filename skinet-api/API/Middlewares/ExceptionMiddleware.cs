using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(IHostEnvironment env, RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, ex.ErrorMessage);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) ex.StatusCode;

                var response = _env.IsDevelopment()
                    ? new ApiExceptionDto{StatusCode = ex.StatusCode, ErrorMessage = ex.ErrorMessage, Details = ex.StackTrace}
                    : new ApiExceptionDto{StatusCode = ex.StatusCode, ErrorMessage = ex.ErrorMessage};
                
                var jsonOptions = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, jsonOptions);

                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiExceptionDto{StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message, Details = ex.StackTrace}
                    : new ApiExceptionDto{StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message};
                
                var jsonOptions = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, jsonOptions);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
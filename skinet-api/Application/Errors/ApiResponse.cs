using System;
using System.Net;

namespace Application.Errors
{
    public class ApiResponse : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponse(HttpStatusCode statusCode, string message = null)
        {
            StatusCode = statusCode;
            ErrorMessage = message ?? GetDefaultErrorMessage(statusCode);
        }

        private string GetDefaultErrorMessage(HttpStatusCode statusCode)
        {
            return StatusCode switch
            {
                HttpStatusCode.Forbidden => "Access denied",
                HttpStatusCode.BadRequest => "A bad request",
                HttpStatusCode.Unauthorized => "You are not authorized",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.Conflict => "Conflicts of data",
                HttpStatusCode.MethodNotAllowed => "Method not allowed",
                HttpStatusCode.InternalServerError => "Internal server error",
                _ => "Errors are the path to dark side. errors lead to anger. anger leads to hate. hate leads to change your work",
            };
        }
    }
}
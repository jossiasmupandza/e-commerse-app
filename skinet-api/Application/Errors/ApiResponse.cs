namespace Application.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultErrorMessage(statusCode);
        }

        private string GetDefaultErrorMessage(int statusCode)
        {
            return StatusCode switch
            {
                400 => "A bad request you have made",
                401 => "You are not authorized",
                404 => "Resource not found",
                500 =>
                    "Errors are the path to dark side. errors lead to anger. anger leads to hate. hate leads to change your work",
                _ => "Internal error"
            };
        }
    }
}
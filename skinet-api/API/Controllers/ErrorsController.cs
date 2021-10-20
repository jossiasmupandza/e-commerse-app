using System.Net;
using Application.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : BaseController
    {
        public IActionResult Error(HttpStatusCode code)
        {
            return new ObjectResult(new ApiResponse(code, "Route not found"));
        }
    }
}
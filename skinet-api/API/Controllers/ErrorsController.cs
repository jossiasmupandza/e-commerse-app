using System.Net;
using Application.Dtos;
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
            throw new ApiException(code);
        }
    }
}
using Application.Errors;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _context.Products.Find(34);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            
            return Ok();
        }
        
        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(34);

            var thongToReturn = thing.ToString();
            
            return Ok();
        }
        
        [HttpGet("badRequest")]
        public ActionResult BadRequests()
        {
            return BadRequest(new ApiResponse(400));
        }
        
        [HttpGet("badRequest/{id}")]
        public ActionResult BadRequests(int id)
        {
            return Ok();
        }
    }
}
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Account.Commands.RequestModals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
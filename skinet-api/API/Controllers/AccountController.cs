using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Account.Commands.RequestModals;
using Application.Features.Account.Queries.RequestModals;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            return await Mediator.Send(new GetCurrentUserQuery());
        }
        
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


        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmilExists([FromQuery] string email)
        {
            return await Mediator.Send(new CheckEmailExistsAsyncQuery{ Email = email});
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            return await Mediator.Send(new GetUserAddressQuery());
        }
        
        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(UpdateUserAddressCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
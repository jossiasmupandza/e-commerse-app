using Application.Dtos;
using MediatR;

namespace Application.Features.Account.Commands.RequestModals
{
    public class LoginCommand : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
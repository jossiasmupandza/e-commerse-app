using Application.Dtos;
using MediatR;

namespace Application.Features.Account.Commands.RequestModals
{
    public class RegisterCommand : IRequest<UserDto>
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
using Application.Dtos;
using MediatR;

namespace Application.Features.Account.Commands.RequestModals
{
    public class UpdateUserAddressCommand : IRequest<AddressDto>
    {
        public AddressDto Address { get; set; }
    }
}
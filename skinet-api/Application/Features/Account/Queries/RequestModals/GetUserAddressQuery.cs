using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Account.Queries.RequestModals
{
    public class GetUserAddressQuery : IRequest<AddressDto>
    {
        
    }
}
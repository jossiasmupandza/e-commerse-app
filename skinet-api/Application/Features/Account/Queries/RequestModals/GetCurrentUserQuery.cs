using Application.Dtos;
using MediatR;

namespace Application.Features.Account.Queries.RequestModals
{
    public class GetCurrentUserQuery : IRequest<UserDto>
    {
        
    }
}
using MediatR;

namespace Application.Features.Account.Queries.RequestModals
{
    public class CheckEmailExistsAsyncQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
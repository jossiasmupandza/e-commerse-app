using MediatR;

namespace Application.Features.Baskets.Commands.RequestModals
{
    public class DeleteBasketQuery : IRequest<bool>
    {
        public string BasketId { get; set; }
    }
}
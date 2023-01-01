using MediatR;

namespace Application.Features.Baskets.Commands.RequestModals
{
    public class DeleteBasketCommand : IRequest<bool>
    {
        public string BasketId { get; set; }
    }
}
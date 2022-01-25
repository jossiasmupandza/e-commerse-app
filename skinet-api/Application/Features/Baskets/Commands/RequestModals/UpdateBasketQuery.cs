using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.RequestModals
{
    public class UpdateBasketQuery : IRequest<CustomerBasket>
    {
        public CustomerBasket CustomerBasket { get; set; }
    }
}
using Domain;
using MediatR;

namespace Application.Features.Baskets.Queries.RequestModals
{
    public class GetBasketByIdQuery : IRequest<CustomerBasket>
    {
        public string BasketId { get; set; }
    }
}
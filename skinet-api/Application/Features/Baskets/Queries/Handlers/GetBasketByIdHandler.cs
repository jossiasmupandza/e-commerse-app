using System.Threading;
using System.Threading.Tasks;
using Application.Features.Baskets.Queries.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Queries.Handlers
{
    public class GetBasketByIdHandler : IRequestHandler<GetBasketByIdQuery, CustomerBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketByIdHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketAsync(request.BasketId);

            return basket ?? new CustomerBasket(request.BasketId);
        }
    }
}
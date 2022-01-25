using System.Threading;
using System.Threading.Tasks;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.Handlers
{
    public class UpdateBasketHandler : IRequestHandler<UpdateBasketQuery, CustomerBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public UpdateBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> Handle(UpdateBasketQuery request, CancellationToken cancellationToken)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(request.CustomerBasket);
            return updatedBasket;
        }
    }
}
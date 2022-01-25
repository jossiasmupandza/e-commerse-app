using System.Threading;
using System.Threading.Tasks;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.Handlers
{
    public class DeleteBasketHandler : IRequestHandler<DeleteBasketQuery, bool>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<bool> Handle(DeleteBasketQuery request, CancellationToken cancellationToken)
        {
            return await _basketRepository.DeleteBasketAsync(request.BasketId);
        }
    }
}
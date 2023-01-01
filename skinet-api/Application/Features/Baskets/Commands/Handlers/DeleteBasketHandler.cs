using System.Threading;
using System.Threading.Tasks;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.Handlers
{
    public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            return await _basketRepository.DeleteBasketAsync(request.BasketId);
        }
    }
}
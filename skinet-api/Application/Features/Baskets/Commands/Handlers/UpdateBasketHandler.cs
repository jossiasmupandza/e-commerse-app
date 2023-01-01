using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.Handlers
{
    public class UpdateBasketHandler : IRequestHandler<UpdateBasketCommand, CustomerBasket>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UpdateBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<CustomerBasket> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var cb = _mapper.Map<CustomerBasketDto, CustomerBasket>(request.CustomerBasket);
            
            var updatedBasket = await _basketRepository.UpdateBasketAsync(cb);
            return updatedBasket;
        }
    }
}
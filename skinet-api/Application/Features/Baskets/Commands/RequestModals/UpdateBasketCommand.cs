using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Baskets.Commands.RequestModals
{
    public class UpdateBasketCommand : IRequest<CustomerBasket>
    {
        public CustomerBasketDto CustomerBasket { get; set; }
    }
}
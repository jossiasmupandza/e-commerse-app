using System.Threading.Tasks;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Features.Baskets.Queries.RequestModals;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string basketId)
        {
            return await Mediator.Send(new GetBasketByIdQuery {BasketId = basketId});
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            return await Mediator.Send(new UpdateBasketQuery {CustomerBasket = basket});
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string basketId)
        {
            return await Mediator.Send(new DeleteBasketQuery {BasketId = basketId});
        }
    }
}
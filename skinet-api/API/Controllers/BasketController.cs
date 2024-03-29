﻿using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Baskets.Commands.RequestModals;
using Application.Features.Baskets.Queries.RequestModals;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            return await Mediator.Send(new GetBasketByIdQuery { BasketId = id });
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            return await Mediator.Send(new UpdateBasketCommand { CustomerBasket = basket });
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            return await Mediator.Send(new DeleteBasketCommand { BasketId = id });
        }
    }
}
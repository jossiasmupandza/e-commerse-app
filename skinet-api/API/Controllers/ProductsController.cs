using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await Mediator.Send(new GetProductByIdQuery{Id = id});
        } 
    }
}
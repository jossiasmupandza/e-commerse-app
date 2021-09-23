﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.ProductBrands.Queries.RequestModal;
using Application.Features.Products.Queries.RequestModels;
using Application.Features.ProductTypes.Queries.RequestModals;
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
        
        [HttpGet("brands")]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await Mediator.Send(new GetProductBrandsQuery());
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
        {
            return await Mediator.Send(new GetProductBrandByIdQuery{Id = id});
        }
        
        [HttpGet("types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await Mediator.Send(new GetProductTypesQuery());
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            return await Mediator.Send(new GetProductTypeByIdQuery{Id = id});
        }
    }
}
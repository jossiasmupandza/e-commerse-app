using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
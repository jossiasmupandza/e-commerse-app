using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<Product>>
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public GetProductsHandler(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            
            return await _genericRepository.ListAsync(spec);
        }
    }
}
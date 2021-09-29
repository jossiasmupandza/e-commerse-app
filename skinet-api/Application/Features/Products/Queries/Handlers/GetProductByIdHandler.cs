using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public GetProductByIdHandler(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(request.Id);
            
            return await _genericRepository.GetEntityWithSpecification(spec);
        }
    }
}
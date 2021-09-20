using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Application.Interfaces;
using Domain;
using MediatR;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(request.Id);
        }
    }
}
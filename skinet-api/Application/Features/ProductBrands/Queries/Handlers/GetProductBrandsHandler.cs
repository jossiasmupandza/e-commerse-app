using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.ProductBrands.Queries.RequestModal;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.ProductBrands.Queries.Handlers
{
    public class GetProductBrandsHandler : IRequestHandler<GetProductBrandsQuery, IReadOnlyList<ProductBrand>>
    {
        private readonly IProductRepository _repository;

        public GetProductBrandsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductBrandsAsync();
        }
    }
}
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
        private readonly IGenericRepository<ProductBrand> _genericRepository;

        public GetProductBrandsHandler(IGenericRepository<ProductBrand> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.ListAllAsync();
        }
    }
}
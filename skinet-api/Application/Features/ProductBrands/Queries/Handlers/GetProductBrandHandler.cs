using System.Threading;
using System.Threading.Tasks;
using Application.Features.ProductBrands.Queries.RequestModal;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.ProductBrands.Queries.Handlers
{
    public class GetProductBrandHandler : IRequestHandler<GetProductBrandByIdQuery, ProductBrand>
    {
        private readonly IGenericRepository<ProductBrand> _genericRepository;

        public GetProductBrandHandler(IGenericRepository<ProductBrand> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ProductBrand> Handle(GetProductBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
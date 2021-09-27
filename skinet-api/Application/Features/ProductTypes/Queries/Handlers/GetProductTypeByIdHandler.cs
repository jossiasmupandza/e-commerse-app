using System.Threading;
using System.Threading.Tasks;
using Application.Features.ProductTypes.Queries.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.ProductTypes.Queries.Handlers
{
    public class GetProductTypeByIdHandler : IRequestHandler<GetProductTypeByIdQuery, ProductType>
    {
        private readonly IGenericRepository<ProductType> _genericRepository;

        public GetProductTypeByIdHandler(IGenericRepository<ProductType> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ProductType> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
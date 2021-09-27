using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.ProductTypes.Queries.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.ProductTypes.Queries.Handlers
{
    public class GetProductTypesHandler : IRequestHandler<GetProductTypesQuery, IReadOnlyList<ProductType>>
    {
        private readonly IGenericRepository<ProductType> _genericRepository;

        public GetProductTypesHandler(IGenericRepository<ProductType> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.ListAllAsync();
        }
    }
}
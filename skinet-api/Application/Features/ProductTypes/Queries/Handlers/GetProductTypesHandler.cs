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
        private readonly IProductRepository _repository;

        public GetProductTypesHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductTypesAsync();
        }
    }
}
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
        private readonly IProductRepository _repository;
        
        public GetProductTypeByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductType> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductTypeByIdAsync(request.Id);
        }
    }
}
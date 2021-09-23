using Domain;
using MediatR;

namespace Application.Features.ProductTypes.Queries.RequestModals
{
    public class GetProductTypeByIdQuery : IRequest<ProductType>
    {
        public int Id { get; set; }
    }
}
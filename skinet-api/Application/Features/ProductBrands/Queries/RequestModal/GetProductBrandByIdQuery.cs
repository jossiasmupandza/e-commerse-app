using Domain;
using MediatR;

namespace Application.Features.ProductBrands.Queries.RequestModal
{
    public class GetProductBrandByIdQuery : IRequest<ProductBrand>
    {
        public int Id { get; set; }
    }
}
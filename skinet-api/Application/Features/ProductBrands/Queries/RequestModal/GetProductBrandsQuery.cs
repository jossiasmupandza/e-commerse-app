using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.ProductBrands.Queries.RequestModal
{
    public class GetProductBrandsQuery : IRequest<IReadOnlyList<ProductBrand>>
    {
        
    }
}
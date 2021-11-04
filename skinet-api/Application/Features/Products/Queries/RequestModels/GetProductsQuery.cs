using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int?  TypeId { get; set; }
    }
}
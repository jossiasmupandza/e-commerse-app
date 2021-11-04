using System.Collections.Generic;
using Application.Dtos;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public SpecParams SpecParams { get; set; }
    }
}
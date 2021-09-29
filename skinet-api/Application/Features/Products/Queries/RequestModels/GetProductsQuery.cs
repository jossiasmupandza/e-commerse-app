using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        
    }
}
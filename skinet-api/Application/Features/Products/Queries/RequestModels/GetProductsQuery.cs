using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductsQuery : IRequest<IReadOnlyList<Product>>
    {
        
    }
}
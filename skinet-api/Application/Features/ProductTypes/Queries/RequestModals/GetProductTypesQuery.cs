using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.ProductTypes.Queries.RequestModals
{
    public class GetProductTypesQuery : IRequest<IReadOnlyList<ProductType>>
    {

    }
}
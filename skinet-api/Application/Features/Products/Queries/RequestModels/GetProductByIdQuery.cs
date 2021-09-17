using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
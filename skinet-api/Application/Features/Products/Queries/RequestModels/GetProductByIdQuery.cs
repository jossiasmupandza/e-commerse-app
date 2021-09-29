using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Products.Queries.RequestModels
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
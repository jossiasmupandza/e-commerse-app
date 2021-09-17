using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Domain;
using MediatR;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly DataContext _context;

        public GetProductByIdHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(request.Id);
        }
    }
}
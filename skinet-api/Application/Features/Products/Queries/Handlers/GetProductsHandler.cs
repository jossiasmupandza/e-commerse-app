using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Products.Queries.RequestModels;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly DataContext _context;

        public GetProductsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync();
        }
    }
}
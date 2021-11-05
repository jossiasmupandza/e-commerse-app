using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Products.Queries.RequestModels;
using Application.Helpers;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, Pagination<ProductDto>>
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var countSpec = new ProductWithFiltersForCountSpecification(request.SpecParams);
            
            var spec = new ProductWithTypesAndBrandsSpecification(request.SpecParams);

            var totalItens = await _genericRepository.CountAsync(countSpec);
            
            var products = await _genericRepository.ListAsync(spec);

            var productsDtos = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            
            return new Pagination<ProductDto>(request.SpecParams.PageIndex, request.SpecParams.PageSize, 
                totalItens, productsDtos);
        }
    }
}
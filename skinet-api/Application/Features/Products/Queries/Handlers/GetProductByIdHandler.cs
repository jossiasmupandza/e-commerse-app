using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using Application.Features.Products.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(request.Id);

            var product = await _genericRepository.GetEntityWithSpecification(spec);

            if (product == null)
                throw new ApiException(HttpStatusCode.NotFound, $"Product with id {request.Id} not found");

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Extensions;
using Application.Features.Account.Queries.RequestModals;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Queries.Handlers
{
    public class GetUserAddressHandler : IRequestHandler<GetUserAddressQuery, AddressDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        
        public GetUserAddressHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AddressDto> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.
                FindByClaimsPrincipalWithAddressAsync(_httpContextAccessor.HttpContext.User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }
    }
}
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using Application.Extensions;
using Application.Features.Account.Commands.RequestModals;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Commands.Handlers
{
    public class UpdateUserAddressHandler : IRequestHandler<UpdateUserAddressCommand, AddressDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserAddressHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AddressDto> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByClaimsPrincipalWithAddressAsync(_httpContextAccessor.HttpContext.User);

            var d = _mapper.Map<AddressDto, Address>(request.Address);

            user.Address = d;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return _mapper.Map<Address, AddressDto>(user.Address);
            
            throw new ApiException(HttpStatusCode.BadRequest, "Problem while updating address");
        }
    }
}
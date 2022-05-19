using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Account.Queries.RequestModals;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Queries.Handlers
{
    public class GetUserAddressHandler : IRequestHandler<GetUserAddressQuery, Address>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public GetUserAddressHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Address> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
        {
            var email = _httpContextAccessor.HttpContext.User?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);

            return user.Address;
        }
    }
}
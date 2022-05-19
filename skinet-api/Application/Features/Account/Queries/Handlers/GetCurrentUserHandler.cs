using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Account.Queries.RequestModals;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Queries.Handlers
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var email = _httpContextAccessor.HttpContext.User?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);
            
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

        }
    }
}
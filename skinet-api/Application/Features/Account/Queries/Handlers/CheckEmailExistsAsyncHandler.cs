using System.Threading;
using System.Threading.Tasks;
using Application.Features.Account.Queries.RequestModals;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Queries.Handlers
{
    public class CheckEmailExistsAsyncHandler : IRequestHandler<CheckEmailExistsAsyncQuery, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public CheckEmailExistsAsyncHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CheckEmailExistsAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(request.Email) != null;
        }
    }
}
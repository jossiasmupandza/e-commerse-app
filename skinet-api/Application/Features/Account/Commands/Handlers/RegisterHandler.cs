﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using Application.Features.Account.Commands.RequestModals;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Commands.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, UserDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                UserName = request.Email
            };
            
            // if the password isn´t strong, an error will be triggered
            // if an email is repeated, an error will be triggered
            var result = await _userManager.CreateAsync(user, request.Password); 
            
            if(!result.Succeeded)
                throw new ApiException(HttpStatusCode.BadRequest);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "This will be a token"
            };
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Application.Dtos;
using MediatR;

namespace Application.Features.Account.Commands.RequestModals
{
    public class RegisterCommand : IRequest<UserDto>
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 digit, 1 non alphanumeric and at least 6 charters")]
        public string Password { get; set; }
    }
}
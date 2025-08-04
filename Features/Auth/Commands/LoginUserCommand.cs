using MediatR;

namespace Products.Features.Auth.Commands
{
    public class LoginUserCommand : IRequest<LoginResult>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Identity;
using Products.Entities;

namespace Products.Features.Auth.Commands.Handlers
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, bool>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutUserCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}

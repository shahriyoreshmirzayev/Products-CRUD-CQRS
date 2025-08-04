using MediatR;
using Microsoft.AspNetCore.Identity;
using Products.Entities;

namespace Products.Features.Auth.Commands.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginUserCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && !user.IsActive)
            {
                return new LoginResult
                {
                    Succeeded = false,
                    ErrorMessage = "Sizning hisobingiz faol emas. Administrator bilan bog'laning."
                };
            }

            var result = await _signInManager.PasswordSignInAsync(
                request.Email,
                request.Password,
                request.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded && user != null)
            {
                user.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
            }

            return new LoginResult
            {
                Succeeded = result.Succeeded,
                IsLockedOut = result.IsLockedOut,
                RequiresTwoFactor = result.RequiresTwoFactor,
                ErrorMessage = result.Succeeded ? null : "Email yoki parol noto'g'ri"
            };
        }
    }
}

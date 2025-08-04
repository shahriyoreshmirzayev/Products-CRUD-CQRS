using MediatR;
using Microsoft.AspNetCore.Identity;
using Products.Entities;

namespace Products.Features.Auth.Commands.Queries.Handlers
{
    public class CheckUserEmailExistsQueryHandler : IRequestHandler<CheckUserEmailExistsQuery, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckUserEmailExistsQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CheckUserEmailExistsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            return user != null;
        }
    }
}

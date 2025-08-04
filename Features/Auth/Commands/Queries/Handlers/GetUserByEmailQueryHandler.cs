using MediatR;
using Microsoft.AspNetCore.Identity;
using Products.Entities;

namespace Products.Features.Auth.Commands.Queries.Handlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ApplicationUser?>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByEmailQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(request.Email);
        }
    }
}

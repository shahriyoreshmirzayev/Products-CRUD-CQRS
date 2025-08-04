using MediatR;
using Products.Entities;

namespace Products.Features.Auth.Commands.Queries
{
    public class GetUserByEmailQuery : IRequest<ApplicationUser?>
    {
        public string Email { get; set; } = string.Empty;
    }
}

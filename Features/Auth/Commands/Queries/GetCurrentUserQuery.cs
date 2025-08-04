using MediatR;
using Products.Models.Auth;

namespace Products.Features.Auth.Commands.Queries
{
    public class GetCurrentUserQuery : IRequest<UserProfileDto?>
    {
        public string UserId { get; set; } = string.Empty;
    }
}

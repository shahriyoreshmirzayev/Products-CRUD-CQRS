using MediatR;

namespace Products.Features.Auth.Commands.Queries
{
    public class CheckUserEmailExistsQuery : IRequest<bool>
    {
        public string Email { get; set; } = string.Empty;
    }
}

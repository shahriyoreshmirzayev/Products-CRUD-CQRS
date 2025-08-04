using MediatR;

namespace Products.Features.Auth.Commands
{
    public class LogoutUserCommand : IRequest<bool>
    {
    }
}

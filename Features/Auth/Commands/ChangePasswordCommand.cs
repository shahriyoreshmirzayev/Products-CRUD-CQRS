using MediatR;

namespace Products.Features.Auth.Commands
{
    public class ChangePasswordCommand : IRequest<ChangePasswordResult>
    {
        public string UserId { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}

namespace Products.Features.Auth.Commands
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

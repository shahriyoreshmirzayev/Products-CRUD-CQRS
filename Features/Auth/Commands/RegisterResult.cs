namespace Products.Features.Auth.Commands
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; } = new();
        public string? UserId { get; set; }
    }
}

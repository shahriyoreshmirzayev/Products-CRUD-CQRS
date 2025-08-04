namespace Products.Features.Auth.Commands
{
    public class ChangePasswordResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}

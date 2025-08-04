using System.ComponentModel.DataAnnotations;

namespace Products.Models.Auth
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email kiritilishi shart")]
        [EmailAddress(ErrorMessage = "Noto'g'ri email format")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
    }
}

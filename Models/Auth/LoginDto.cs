using System.ComponentModel.DataAnnotations;

namespace Products.Models.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "Email kiritilishi shart")]
    [EmailAddress(ErrorMessage = "Noto'g'ri email format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parol kiritilishi shart")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Meni eslab qol")]
    public bool RememberMe { get; set; }
}

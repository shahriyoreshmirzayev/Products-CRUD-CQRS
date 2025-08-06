using System.ComponentModel.DataAnnotations;

namespace Products.Models.Auth;

public class UserProfileDto
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ism kiritilishi shart")]
    [StringLength(50, ErrorMessage = "Ism 50 ta belgidan oshmasligi kerak")]
    [Display(Name = "Ism")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Familiya kiritilishi shart")]
    [StringLength(50, ErrorMessage = "Familiya 50 ta belgidan oshmasligi kerak")]
    [Display(Name = "Familiya")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email kiritilishi shart")]
    [EmailAddress(ErrorMessage = "Noto'g'ri email format")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Telefon")]
    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}

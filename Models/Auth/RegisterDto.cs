using System.ComponentModel.DataAnnotations;

namespace Products.Models.Auth
{
    public class RegisterDto
    {
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

        [Required(ErrorMessage = "Parol kiritilishi shart")]
        [StringLength(100, ErrorMessage = "Parol kamida {2} ta belgidan iborat bo'lishi kerak", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parol")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Parolni tasdiqlang")]
        [Compare("Password", ErrorMessage = "Parollar mos kelmaydi")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

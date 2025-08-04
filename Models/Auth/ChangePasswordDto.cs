using System.ComponentModel.DataAnnotations;

namespace Products.Models.Auth
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Joriy parol kiritilishi shart")]
        [DataType(DataType.Password)]
        [Display(Name = "Joriy parol")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yangi parol kiritilishi shart")]
        [StringLength(100, ErrorMessage = "Parol kamida {2} ta belgidan iborat bo'lishi kerak", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yangi parol")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Yangi parolni tasdiqlang")]
        [Compare("NewPassword", ErrorMessage = "Parollar mos kelmaydi")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}

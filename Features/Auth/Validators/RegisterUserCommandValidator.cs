using FluentValidation;
using Products.Features.Auth.Commands;

namespace Products.Features.Auth.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ism kiritilishi shart")
                .MaximumLength(50).WithMessage("Ism 50 ta belgidan oshmasligi kerak")
                .Matches(@"^[a-zA-ZА-Яа-я\s]*$").WithMessage("Ismda faqat harflar bo'lishi kerak");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Familiya kiritilishi shart")
                .MaximumLength(50).WithMessage("Familiya 50 ta belgidan oshmasligi kerak")
                .Matches(@"^[a-zA-ZА-Яа-я\s]*$").WithMessage("Familiyada faqat harflar bo'lishi kerak");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email kiritilishi shart")
                .EmailAddress().WithMessage("Noto'g'ri email format")
                .MaximumLength(256).WithMessage("Email 256 ta belgidan oshmasligi kerak");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parol kiritilishi shart")
                .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak")
                .MaximumLength(100).WithMessage("Parol 100 ta belgidan oshmasligi kerak")
                .Matches(@".*\d.*").WithMessage("Parol kamida bitta raqam o'z ichiga olishi kerak");
        }
    }
}

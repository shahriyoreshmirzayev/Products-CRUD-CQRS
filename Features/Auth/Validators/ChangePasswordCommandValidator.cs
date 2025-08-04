using FluentValidation;
using Products.Features.Auth.Commands;

namespace Products.Features.Auth.Validators
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Foydalanuvchi ID kiritilishi shart");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Joriy parol kiritilishi shart");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Yangi parol kiritilishi shart")
                .MinimumLength(6).WithMessage("Yangi parol kamida 6 ta belgidan iborat bo'lishi kerak")
                .MaximumLength(100).WithMessage("Yangi parol 100 ta belgidan oshmasligi kerak")
                .Matches(@".*\d.*").WithMessage("Yangi parol kamida bitta raqam o'z ichiga olishi kerak")
                .NotEqual(x => x.CurrentPassword).WithMessage("Yangi parol joriy paroldan farq qilishi kerak");
        }
    }
}

using FluentValidation;
using Products.Features.Auth.Commands;

namespace Products.Features.Auth.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email kiritilishi shart")
                .EmailAddress().WithMessage("Noto'g'ri email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parol kiritilishi shart");
        }
    }
}

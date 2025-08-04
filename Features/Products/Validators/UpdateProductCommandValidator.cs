using FluentValidation;
using Products.Features.Products.Commands;

namespace Products.Features.Products.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("ID noto'g'ri");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Mahsulot nomi bo'sh bo'lmasligi kerak")
            .MaximumLength(100).WithMessage("Mahsulot nomi 100 ta belgidan oshmasligi kerak");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Tavsif 500 ta belgidan oshmasligi kerak");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Narx 0 dan katta bo'lishi kerak");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Soni 0 dan kichik bo'lmasligi kerak");
    }
}

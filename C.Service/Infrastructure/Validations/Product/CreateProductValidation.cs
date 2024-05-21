using C.Service.Infrastructure.Requests.Product;
using FluentValidation;

namespace C.Service.Infrastructure.Validations.Product;
public class CreateProductValidation : AbstractValidator<CreateProductReq>
{
    public CreateProductValidation()
    {
        RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(m => m.Name).MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(m => m.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(m => m.Description).MaximumLength(250).WithMessage("Description must be less than 250 characters");

        RuleFor(m => m.Price).Must(x => x > 0).WithMessage("Price must be greater than 0");

        RuleFor(m => m.Stock).Must(x => x > 0).WithMessage("Price must be greater than 0");
    }
}

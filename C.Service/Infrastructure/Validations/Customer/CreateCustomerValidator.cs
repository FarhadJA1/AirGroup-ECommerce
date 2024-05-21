using C.Service.Infrastructure.Requests.Customer;
using FluentValidation;

namespace C.Service.Infrastructure.Validations.Customer;
public class CreateCustomerValidator : AbstractValidator<CreateCustomerReq>
{
    public CreateCustomerValidator()
    {
        RuleFor(m => m.Firstname).NotEmpty().WithMessage("Firstname is required");
        RuleFor(m => m.Firstname).MaximumLength(50).WithMessage("Firstname must be less than 50 characters");

        RuleFor(m => m.Lastname).NotEmpty().WithMessage("Firstname is required");
        RuleFor(m => m.Lastname).MaximumLength(50).WithMessage("Firstname must be less than 50 characters");

        RuleFor(m => m.Gender).IsInEnum().WithMessage("Gender is not proper");
    }
}

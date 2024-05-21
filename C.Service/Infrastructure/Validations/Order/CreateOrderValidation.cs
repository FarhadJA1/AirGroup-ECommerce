using C.Service.Infrastructure.Requests.Order;
using FluentValidation;

namespace C.Service.Infrastructure.Validations.Order;
public class CreateOrderValidation : AbstractValidator<CreateOrderReq>
{
    public CreateOrderValidation()
    {
        RuleForEach(m => m.OrderItems).SetValidator(new CreateOrderItemValidation());

        RuleFor(m => m.CustomerId).Must(x => x > 0).WithMessage("Customer must be specified");
    }
}

public class CreateOrderItemValidation : AbstractValidator<CreateOrderItemReq>
{
    public CreateOrderItemValidation()
    {
        RuleFor(m => m.ProductId).Must(x => x > 0).WithMessage("Product must be specified");

        RuleFor(m => m.Quantity).Must(x => x > 0).WithMessage("Quantity must be greater than 0");
    }
}

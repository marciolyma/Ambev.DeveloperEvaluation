using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerValidator()
        {
            RuleFor(customer => customer.Id)
                .NotEmpty()
                .WithMessage("Customer ID cannot be empty.");
        }
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    public class GetCustomerCommandValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id)
                .NotEmpty()
                .WithMessage("Customer ID cannot be empty.");
        }
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(customer => customer.Id)
                .NotEmpty()
                .WithMessage("Customer ID cannot be empty.");
        }
    }
}

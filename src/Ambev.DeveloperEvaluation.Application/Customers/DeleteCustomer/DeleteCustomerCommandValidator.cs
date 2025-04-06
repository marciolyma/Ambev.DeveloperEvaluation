using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id)
                .NotEmpty()
                .WithMessage("Customer ID cannot be empty.");
        }
    }
}

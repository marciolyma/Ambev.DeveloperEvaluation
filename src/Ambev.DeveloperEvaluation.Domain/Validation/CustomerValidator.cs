using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty()
                .WithMessage("Customer name cannot be None")
                .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Customer name cannot be longer than 100 characters.");
        }
    }
}

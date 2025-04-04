using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters");
        }
    }
}

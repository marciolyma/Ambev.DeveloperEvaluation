using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product Name cannot be None")
                .MinimumLength(3).WithMessage("Product Name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Product Name cannot be longer than 100 characters.");

            RuleFor(product => product.Price)
                .Must(ValidPrice).WithMessage("Price must be greater than 0");
        }
        protected static bool ValidPrice(decimal price)
        {
            return price > 0;
        }
    }
}

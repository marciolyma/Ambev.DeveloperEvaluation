using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number cannot be None");

            RuleFor(sale => sale.TotalAmount)
                .Must(ValidAmount)
                .WithMessage("Total Amount must be greater than 0");
        }

        protected static bool ValidAmount(decimal totalAmount)
        {
            return totalAmount > 0;
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(saleItem => saleItem.Quantity)
                .NotEmpty().WithMessage("Product Name must be greater than 0");

            RuleFor(saleItem => saleItem.UnitPrice)
                .Must(ValidUnitPrice).WithMessage("Unit Price must be greater than 0");

            RuleFor(sale => sale.TotalAmount)
                .Must(ValidAmount)
                .WithMessage("Total Amount must be greater than 0");
            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1.")
                .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");
        }

        protected static bool ValidUnitPrice(decimal unitPrice)
        {
            return unitPrice > 0;
        }

        protected static bool ValidAmount(decimal totalAmount)
        {
            return totalAmount > 0;
        }

    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(saleItem => saleItem.ProductName)
            .NotEmpty().WithMessage("ProductName cannot be None")
            .MinimumLength(3).WithMessage("ProductName must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("ProductName cannot be longer than 50 characters.");

            RuleFor(saleItem => saleItem.Quantity)
                .NotEmpty().WithMessage("Product Name must be greater than 0");

            RuleFor(saleItem => saleItem.UnitPrice)
                .Must(ValidUnitPrice).WithMessage("Unit Price must be greater than 0");

            RuleFor(sale => sale.TotalAmount)
                .Must(ValidAmount)
                .WithMessage("Total Amount must be greater than 0");

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

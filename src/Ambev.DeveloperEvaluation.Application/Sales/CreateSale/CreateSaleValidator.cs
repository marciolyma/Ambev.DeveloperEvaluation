using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number cannot be None");

            RuleFor(sale => sale.Customer)
            .NotEmpty().WithMessage("Customer cannot be None")
            .MinimumLength(3).WithMessage("Customer must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Customer cannot be longer than 100 characters.");

            RuleFor(sale => sale.Branch)
                .Must(ValidBranch)
                .WithMessage("Branch Must be between 3 and 100 characters long");

            RuleFor(sale => sale.TotalAmount)
                .Must(ValidAmount)
                .WithMessage("Total Amount must be greater than 0");

        }

        protected static bool ValidBranch(string branch)
        {
            if (!String.IsNullOrEmpty(branch) && (branch.Length < 3 || branch.Length > 100)) return false;

            return true;
        }

        protected static bool ValidAmount(decimal totalAmount)
        {
            return totalAmount > 0;
        }
    }
}

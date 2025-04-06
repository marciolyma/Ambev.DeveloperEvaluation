using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem
{
    /// <summary>
    /// Validator for the CreateSaleItemCommand.
    /// </summary>
    public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleItemValidator with defined validation rules.
        /// </summary>
        public CreateSaleItemCommandValidator()
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

        /// <summary>
        /// Validates if the unit price is greater than 0.
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        protected static bool ValidUnitPrice(decimal unitPrice)
        {
            return unitPrice > 0;
        }

        /// <summary>
        /// Validates if the total amount is greater than 0.
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        protected static bool ValidAmount(decimal totalAmount)
        {
            return totalAmount > 0;
        }

    }
}


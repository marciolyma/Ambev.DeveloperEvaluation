using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    public class DeleteSaleItemValidator : AbstractValidator<DeleteSaleItemCommand>
    {
        public DeleteSaleItemValidator()
        {
            RuleFor(saleItem => saleItem.Id)
                .NotEmpty().WithMessage("Id cannot be None");
        }
    }
}

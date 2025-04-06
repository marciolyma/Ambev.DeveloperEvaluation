using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    public class DeleteSaleItemCommandValidator : AbstractValidator<DeleteSaleItemCommand>
    {
        public DeleteSaleItemCommandValidator()
        {
            RuleFor(saleItem => saleItem.Id)
                .NotEmpty().WithMessage("Id cannot be None");
        }
    }
}

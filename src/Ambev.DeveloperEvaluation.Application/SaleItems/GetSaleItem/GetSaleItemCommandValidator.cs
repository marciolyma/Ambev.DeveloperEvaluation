using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem
{
    public class GetSaleItemCommandValidator : AbstractValidator<GetSaleItemCommand>
    {
        public GetSaleItemCommandValidator()
        {
            RuleFor(saleItem => saleItem.Id)
                .NotEmpty().WithMessage("Id cannot be None");
        }
    }
}

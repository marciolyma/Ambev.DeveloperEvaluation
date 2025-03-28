using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem
{
    public class GetSaleItemValidator : AbstractValidator<GetSaleItemCommand>
    {
        public GetSaleItemValidator()
        {
            RuleFor(saleItem => saleItem.Id)
                .NotEmpty().WithMessage("Id cannot be None");
        }
    }
}

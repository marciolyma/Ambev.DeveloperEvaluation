using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty()
                .WithMessage("BranchId is required.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be at least 1.")
                    .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 items of the same product in a single line.");
            });
        }
    }
    {
    }
}

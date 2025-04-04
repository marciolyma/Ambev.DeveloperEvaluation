using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    public class CreateBrancheRequestValidator : AbstractValidator<CreateBrancheRequest>
    {
        public CreateBrancheRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name must be less than 100 characters");
        }
    }
}

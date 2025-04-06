using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch
{
    public class GetBranchCommandValidator : AbstractValidator<GetBranchCommand>
    {
        public GetBranchCommandValidator()
        {
            RuleFor(branch => branch.Id).
                NotEmpty()
                .WithMessage("Branch Id cannot be empty");
        }
    }
}

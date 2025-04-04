using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch
{
    public class GetBranchValidator : AbstractValidator<GetBranchCommand>
    {
        public GetBranchValidator()
        {
            RuleFor(branch => branch.Id).
                NotEmpty()
                .WithMessage("Branch Id cannot be empty");
        }
    }
}

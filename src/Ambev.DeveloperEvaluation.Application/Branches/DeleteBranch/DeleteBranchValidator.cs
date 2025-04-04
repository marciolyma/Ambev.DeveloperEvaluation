using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch
{
    public class DeleteBranchValidator : AbstractValidator<DeleteBranchCommand>
    {
        public DeleteBranchValidator()
        {
            RuleFor(branch => branch.Id)
                .NotEmpty()
                .WithMessage("Branch Id cannot be empty");
        }
    }
}

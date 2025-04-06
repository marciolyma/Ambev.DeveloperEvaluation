using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch
{
    public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
    {
        public DeleteBranchCommandValidator()
        {
            RuleFor(branch => branch.Id)
                .NotEmpty()
                .WithMessage("Branch Id cannot be empty");
        }
    }
}

﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator()
        {
            RuleFor(branch => branch.Name)
                .NotEmpty()
                .WithMessage("Branch name cannot be empty")
                .Length(3, 100).WithMessage("Branch name must be between 3 and 100 characters");
        }
    }
}

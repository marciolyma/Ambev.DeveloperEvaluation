﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");
        }
    }
}

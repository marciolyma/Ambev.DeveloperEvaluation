﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product Name cannot be None")
                .MinimumLength(3).WithMessage("Product Name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Product Name cannot be longer than 100 characters.");

            RuleFor(cmd => cmd.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(cmd => !string.IsNullOrEmpty(cmd.Description));


            RuleFor(product => product.UnitPrice)
                .Must(ValidPrice).WithMessage("Price must be greater than 0");
        }
        protected static bool ValidPrice(decimal price)
        {
            return price > 0;
        }
    }
}

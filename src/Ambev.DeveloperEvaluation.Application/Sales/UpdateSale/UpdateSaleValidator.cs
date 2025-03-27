﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(sale => sale.SaleNumber).NotEmpty();
            RuleFor(sale => sale.Customer).NotEmpty().Length(3, 100);
            RuleFor(sale => sale.Branch).Must(ValidBranch);
            RuleFor(sale => sale.TotalAmount).Must(ValidAmount);
            RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);
        }
        protected static bool ValidBranch(string branch)
        {
            if (!String.IsNullOrEmpty(branch) && (branch.Length < 3 || branch.Length > 100)) return false;
            return true;
        }
        protected static bool ValidAmount(decimal totalAmount)
        {
            return totalAmount > 0;
        }
    }
}

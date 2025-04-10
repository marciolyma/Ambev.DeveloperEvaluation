﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system.
    /// </summary>
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public Guid BranchId { get; set; } 
        public SaleStatus Status { get; set; }
        public virtual List<SaleItem>? SaleItems { get; set; }
        public virtual Branch Branch { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the sale's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class.
        /// </summary>
        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Activates the sale account.
        /// Changes the sale's status to Active.
        /// </summary>
        public void Activate()
        {
            Status = SaleStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the sale account.
        /// Changes the sale's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            Status = SaleStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public void CancelSale()
        {
            Status = SaleStatus.Cenceled;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}

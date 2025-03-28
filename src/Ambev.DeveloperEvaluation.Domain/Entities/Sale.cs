using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system.
    /// </summary>
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItem>? SaleItems { get; set; }
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the sale's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

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

    }
}

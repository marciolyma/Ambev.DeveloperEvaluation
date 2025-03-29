namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Result of the DeleteSaleItemCommand.
    /// </summary>
    public class DeleteSaleItemResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sale item was successfully deleted.
        /// </summary>
        public bool Success { get; set; }
    }
}

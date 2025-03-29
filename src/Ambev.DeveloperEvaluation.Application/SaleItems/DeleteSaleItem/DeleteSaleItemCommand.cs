using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Command to delete a SaleItem.
    /// </summary>
    public class DeleteSaleItemCommand : IRequest<DeleteSaleItemResponse>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the DeleteSaleItemCommand class.
        /// </summary>
        /// <param name="id"></param>
        public DeleteSaleItemCommand(Guid id)
        {
            Id = id;
        }
    }
}

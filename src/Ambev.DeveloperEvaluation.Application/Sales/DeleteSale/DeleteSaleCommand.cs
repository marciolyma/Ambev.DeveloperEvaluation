using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Command for deleting a sale
    /// </summary>
    public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the sale to be deleted.
        /// </summary>
        public Guid Id { get; }

        /// <param name="id">The ID of the sale to /// <summary>
        /// Initializes a new instance of DeleteSaleCommand
        /// </summary>delete</param>
        public DeleteSaleCommand(Guid id)
        {
            id = Id;
        }
    }
}

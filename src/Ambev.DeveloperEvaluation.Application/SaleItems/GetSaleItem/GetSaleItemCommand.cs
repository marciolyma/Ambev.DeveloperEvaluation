using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem
{
    /// <summary>
    /// Command to get a sale item.
    /// </summary>
    public class GetSaleItemCommand : IRequest<GetSaleItemResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        public Guid Id { get; set; }
        public GetSaleItemCommand(Guid id)
        {
            Id = id;
        }
    }
}

using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        /// <summary>
        /// Gets or sets the id of the product.
        /// </summary>
        public Guid Id { get; set; }
    }
}

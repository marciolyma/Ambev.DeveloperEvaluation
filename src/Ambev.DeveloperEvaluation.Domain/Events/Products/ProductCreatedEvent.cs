using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Products
{
    public class ProductCreatedEvent : INotification
    {
        public Product Product { get;}

        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }
    }
}

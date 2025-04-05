using MediatR;
using Serilog;

namespace Ambev.DeveloperEvaluation.Domain.Events.Products
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Product created: {notification.Product}");
            return Task.CompletedTask;
        }
    }
}

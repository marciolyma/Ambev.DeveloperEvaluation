using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event here
            // For example, you could log the event or perform some other action
            Console.WriteLine($"Sale created: {notification.Sale}");
            return Task.CompletedTask;
        }
    }
}

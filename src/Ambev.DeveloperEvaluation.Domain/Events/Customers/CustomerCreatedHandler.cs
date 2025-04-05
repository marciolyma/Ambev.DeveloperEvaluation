using MediatR;
using Serilog;

namespace Ambev.DeveloperEvaluation.Domain.Events.Customers
{
    public class CustomerCreatedHandler : INotificationHandler<CustomerCreatedEvent>
    {


        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event here
            // For example, you could log the event or perform some other action
            Log.Information($"Customer created: {notification.Customer}");
            return Task.CompletedTask;
        }
    }
}

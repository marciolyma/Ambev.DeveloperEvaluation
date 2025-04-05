using MediatR;
using Serilog;

namespace Ambev.DeveloperEvaluation.Domain.Events.Branches
{
    public class BranchCrreatedEventHandler : INotificationHandler<BranchCreatedEvent>
    {
        public Task Handle(BranchCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event here
            // For example, you could log the event or perform some other action
            Log.Information($"Branch created: {notification.Branch}");
            return Task.CompletedTask;
        }
    }
}

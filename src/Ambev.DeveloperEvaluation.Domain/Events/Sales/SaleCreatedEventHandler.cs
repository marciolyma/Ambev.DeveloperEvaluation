﻿using MediatR;
using Serilog;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Sale created: {notification.Sale}");
            return Task.CompletedTask;
        }

        public Task Handle(SaleCanceledEvent notification, CancellationToken cancellationToken)
        {
            Log.Information($"Sale canceled: {notification.SaleId}");
            return Task.CompletedTask;
        }
    }
}

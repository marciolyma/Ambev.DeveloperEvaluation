using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCreatedEvent : INotification
    {
        public SaleCreatedEvent(Sale sale)
        {
            Sale = sale;
        }
        public Sale Sale { get; }
    }
}

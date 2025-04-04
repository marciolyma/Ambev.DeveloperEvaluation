using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Customers
{
    public class CustomerCreatedEvent : INotification
    {
        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }
        public Customer Customer { get; }
    }
}

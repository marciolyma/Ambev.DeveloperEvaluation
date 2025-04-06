using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCanceledEvent : INotification
    {
        public SaleCanceledEvent(Guid saleId)
        {
            SaleId = saleId;
        }
        public Guid SaleId { get; }
    }
}

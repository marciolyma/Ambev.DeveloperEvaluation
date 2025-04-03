using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<(List<Customer> Customers, int TotalCount)> GetAllPagedAsync(
            int pageNumber,
            int psgeSize,
            CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}

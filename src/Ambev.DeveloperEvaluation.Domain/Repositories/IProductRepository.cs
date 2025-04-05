using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<(List<Product>, int TotalAcount)> GetByAllPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}

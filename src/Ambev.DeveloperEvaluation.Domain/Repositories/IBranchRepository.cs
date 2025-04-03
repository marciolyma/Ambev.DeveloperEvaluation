using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<(List<Branch> Branches, int TotalAcount)> GetAllPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default);
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<(List<Branch> Branches, int TotalAcount)> GetByCustomerIdPagedAsync(
            Guid CustomerId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default);
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}

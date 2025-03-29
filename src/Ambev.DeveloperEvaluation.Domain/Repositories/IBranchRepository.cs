using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}

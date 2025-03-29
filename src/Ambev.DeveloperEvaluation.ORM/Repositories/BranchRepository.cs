using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Branch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Branches.ToListAsync(cancellationToken);
        }

        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Branches.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }


        public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            await _context.Branches.AddAsync(branch, cancellationToken);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch> UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            _context.Update(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var branch = await GetByIdAsync(Id, cancellationToken);
            if (branch == null)
                return false;

            _context.Remove(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}

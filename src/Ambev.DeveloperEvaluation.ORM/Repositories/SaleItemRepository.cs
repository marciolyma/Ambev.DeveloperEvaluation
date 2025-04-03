using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Repository for SaleItem entity
    /// </summary>
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all SaleItems
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(List<SaleItem> SaleItems, int TotalCount)> GetAllPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = _context.SaleItems.AsQueryable();
            var totalCount = await query.CountAsync(cancellationToken);
            var saleItems = await query
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (saleItems, totalCount);
        }

        /// <summary>
        /// Get SaleItem by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        /// <summary>
        /// Get SaleItems by SaleId
        /// </summary>
        /// <param name="saleId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<SaleItem>?> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.Where(s => s.SaleId == saleId).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Create a new SaleItem
        /// </summary>
        /// <param name="saleItem"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.SaleItems.AddAsync(saleItem, cancellationToken);
            await _context.SaveChangesAsync();

            return saleItem;
        }

        /// <summary>
        /// Update a SaleItem
        /// </summary>
        /// <param name="saleItem"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SaleItem> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            _context.Update(saleItem);
            await _context.SaveChangesAsync();

            return saleItem;
        }

        /// <summary>
        /// Delete a SaleItem
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var saleItem = await GetByIdAsync(Id, cancellationToken);

            if(saleItem == null)
                return false;

            _context.Remove(saleItem);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

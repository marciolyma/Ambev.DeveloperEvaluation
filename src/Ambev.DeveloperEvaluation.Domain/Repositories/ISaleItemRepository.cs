﻿using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {
        Task<List<SaleItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<SaleItem>?> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);
        Task<SaleItem> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}

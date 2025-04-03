using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _context;

        public CustomerRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<(List<Domain.Entities.Customer> Customers, int TotalCount)> GetAllPagedAsync(int pageNumber, int psgeSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Customers.AsQueryable();
            var totalCount = await query.CountAsync(cancellationToken);
            var customers = await query
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * psgeSize)
                .Take(psgeSize)
                .ToListAsync(cancellationToken);

            return (customers, totalCount);
        }
        public Task<Domain.Entities.Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
        public async Task<Domain.Entities.Customer> CreateAsync(Domain.Entities.Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }
        public async Task<Domain.Entities.Customer> UpdateAsync(Domain.Entities.Customer customer, CancellationToken cancellationToken = default)
        {
            var existingCustomer = await GetByIdAsync(customer.Id, cancellationToken);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            _context.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;

        }
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}

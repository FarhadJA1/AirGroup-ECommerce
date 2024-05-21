using A.Domain.Entities;
using B.Repository.Abstractions;
using B.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace B.Repository.Implementations;
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public IQueryable<Customer> GetAllCustomersAsync()
    {
        return _context.Customers
            .Where(m => !m.IsDeleted)
            .OrderByDescending(m => m.Id)
            .AsQueryable();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
    }
}

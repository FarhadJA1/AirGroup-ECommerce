using A.Domain.Entities;

namespace B.Repository.Abstractions;
public interface ICustomerRepository
{
    Task CreateCustomerAsync(Customer customer);
    Task<Customer?> GetCustomerByIdAsync(int id);
    IQueryable<Customer> GetAllCustomersAsync();
}

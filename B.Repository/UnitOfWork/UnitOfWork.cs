using B.Repository.Abstractions;
using B.Repository.Data;
using B.Repository.Implementations;

namespace B.Repository.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ICustomerRepository _customerRepository;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);
    public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_context);
    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

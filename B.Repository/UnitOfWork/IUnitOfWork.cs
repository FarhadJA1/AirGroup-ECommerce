using B.Repository.Abstractions;

namespace B.Repository.UnitOfWork;
public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository { get; }
    IOrderRepository OrderRepository { get; }
    IProductRepository ProductRepository { get; }
    Task SaveChangesAsync();
}

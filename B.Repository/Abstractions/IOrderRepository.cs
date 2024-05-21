using A.Domain.Entities;

namespace B.Repository.Abstractions;
public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    IQueryable<Order> GetAllOrdersAsync();
}

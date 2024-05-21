using A.Domain.Entities;
using B.Repository.Abstractions;
using B.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace B.Repository.Implementations;
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _context.Orders
            .AddAsync(order);
    }

    public IQueryable<Order> GetAllOrdersAsync()
    {
        return _context.Orders
            .Include(m => m.Customer)
            .Include(m => m.OrderItems)
                .ThenInclude(m => m.Product)
            .OrderByDescending(m => m.Id)
            .AsQueryable();
    }
}

using A.Domain.Entities;
using B.Repository.Abstractions;
using B.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace B.Repository.Implementations;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public IQueryable<Product> GetAllProductsAsync()
    {
        return _context.Products
            .Where(m => !m.IsDeleted)
            .OrderByDescending(m => m.Id)
            .AsQueryable();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
    }
}

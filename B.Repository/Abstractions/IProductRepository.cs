using A.Domain.Entities;

namespace B.Repository.Abstractions;
public interface IProductRepository
{
    Task CreateProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);
    IQueryable<Product> GetAllProductsAsync();
}

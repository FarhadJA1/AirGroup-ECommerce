using A.Domain.Entities;
using B.Repository.UnitOfWork;
using C.Service.Abstractions;
using C.Service.Infrastructure.Dtos.Product;
using C.Service.Infrastructure.Requests.Product;
using C.Service.Infrastructure.Responses;
using C.Service.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace C.Service.Implementations;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PostResponse> CreateProductAsync(CreateProductReq input)
    {
        var product = new Product()
        {
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            Stock = input.Stock,
            IsDeleted = false,
        };

        await _unitOfWork.ProductRepository.CreateProductAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }

    public async Task<PostResponse> DeleteProductAsync(int id)
    {
        if (id <= 0) return new PostResponse(false, "Product was not found");

        var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(id);

        if (product is null) return new PostResponse(false, "Product was not found");

        product.IsDeleted = true;

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }

    public async Task<GetAllResponse<ProductDto>> GetAllProductsAsync()
    {
        var products = _unitOfWork.ProductRepository.GetAllProductsAsync();

        if (!products.Any())
            return new GetAllResponse<ProductDto>(false, "No customer was found");

        var result = await products.Select(m => new ProductDto()
        {
            Description = m.Description,
            Id = m.Id,
            Name = m.Name,
            Price = m.Price,
            Stock = m.Stock
        }).ToListAsync();

        return new GetAllResponse<ProductDto>(true, result);
    }

    public async Task<PostResponse> UpdateProductAsync(UpdateProductReq input)
    {
        var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(input.Id);

        if (product is null) return new PostResponse(false, "Product was not found");

        if (InputHelper.IsInputProper(product.Name, input.Name))
            product.Name = input.Name;

        if (InputHelper.IsInputProper(product.Description, input.Description))
            product.Description = input.Description;

        if (product.Price != input.Price)
            product.Price = input.Price;

        if (product.Stock != input.Stock)
            product.Stock = input.Stock;

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }
}

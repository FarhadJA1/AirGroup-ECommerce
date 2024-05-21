using C.Service.Infrastructure.Dtos.Product;
using C.Service.Infrastructure.Requests.Product;
using C.Service.Infrastructure.Responses;

namespace C.Service.Abstractions;
public interface IProductService
{
    Task<PostResponse> CreateProductAsync(CreateProductReq input);
    Task<PostResponse> UpdateProductAsync(UpdateProductReq input);
    Task<GetAllResponse<ProductDto>> GetAllProductsAsync();
    Task<PostResponse> DeleteProductAsync(int id);
}

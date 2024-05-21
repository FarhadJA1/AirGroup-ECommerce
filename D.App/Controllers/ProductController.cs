using C.Service.Abstractions;
using C.Service.Infrastructure.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace D.App.Controllers;
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductReq input)
    {
        var result = await _productService.CreateProductAsync(input);

        if (!result.Succeeded)
            return GenericClientError(result.Message);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductReq input)
    {
        var result = await _productService.UpdateProductAsync(input);

        if (!result.Succeeded)
            return GenericClientError(result.Message);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var result = await _productService.DeleteProductAsync(id);

        if (!result.Succeeded)
            return GenericClientError(result.Message);

        return Ok(result);
    }
}

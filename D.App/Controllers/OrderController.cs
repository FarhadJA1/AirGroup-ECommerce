using C.Service.Abstractions;
using C.Service.Infrastructure.Requests.Order;
using Microsoft.AspNetCore.Mvc;

namespace D.App.Controllers;
public class OrderController : BaseController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderReq input)
    {
        var result = await _orderService.CreateOrderAsync(input);

        if (!result.Succeeded)
            return GenericClientError(result.Message);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        return Ok(await _orderService.GetAllOrdersAsync());
    }
}

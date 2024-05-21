using C.Service.Infrastructure.Dtos.Order;
using C.Service.Infrastructure.Requests.Order;
using C.Service.Infrastructure.Responses;

namespace C.Service.Abstractions;
public interface IOrderService
{
    Task<PostResponse> CreateOrderAsync(CreateOrderReq input);
    Task<GetAllResponse<OrderDto>> GetAllOrdersAsync();
}

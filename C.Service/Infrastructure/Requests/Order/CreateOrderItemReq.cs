namespace C.Service.Infrastructure.Requests.Order;
public class CreateOrderItemReq
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

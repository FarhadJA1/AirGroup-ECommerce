namespace C.Service.Infrastructure.Requests.Order;
public class CreateOrderReq
{
    public int CustomerId { get; set; }
    public List<CreateOrderItemReq> OrderItems { get; set; }
}

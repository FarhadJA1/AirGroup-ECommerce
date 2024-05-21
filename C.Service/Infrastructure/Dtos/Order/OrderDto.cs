namespace C.Service.Infrastructure.Dtos.Order;
public class OrderDto
{
    public int Id { get; set; }
    public string CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderCustomer Customer { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}

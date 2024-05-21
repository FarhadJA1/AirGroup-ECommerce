namespace A.Domain.Entities;
public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CustomerId { get; set; }



    public List<OrderItem> OrderItems { get; set; }
    public Customer Customer { get; set; }
}

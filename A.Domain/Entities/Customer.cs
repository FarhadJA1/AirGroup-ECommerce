using A.Domain.Enums;

namespace A.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Genders Gender { get; set; }
    public bool IsDeleted { get; set; }


    public List<Order> Orders { get; set; }
}

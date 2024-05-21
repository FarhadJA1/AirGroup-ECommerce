using A.Domain.Enums;

namespace C.Service.Infrastructure.Dtos.Customer;
public class CustomerDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Genders Gender { get; set; }
}

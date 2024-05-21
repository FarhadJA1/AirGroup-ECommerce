using C.Service.Infrastructure.Dtos.Customer;
using C.Service.Infrastructure.Requests.Customer;
using C.Service.Infrastructure.Responses;

namespace C.Service.Abstractions;
public interface ICustomerService
{
    Task<PostResponse> CreateCustomerAsync(CreateCustomerReq input);
    Task<PostResponse> UpdateCustomerAsync(UpdateCustomerReq input);
    Task<PostResponse> DeleteCustomerAsync(int id);
    Task<GetAllResponse<CustomerDto>> GetAllCustomersAsync();
}

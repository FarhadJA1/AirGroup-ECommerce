using C.Service.Abstractions;
using C.Service.Infrastructure.Requests.Customer;
using Microsoft.AspNetCore.Mvc;

namespace D.App.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerReq input)
        {
            var result = await _customerService.CreateCustomerAsync(input);

            if (!result.Succeeded)
                return GenericClientError(result.Message);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerReq input)
        {
            var result = await _customerService.UpdateCustomerAsync(input);

            if (!result.Succeeded)
                return GenericClientError(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);

            if (!result.Succeeded)
                return GenericClientError(result.Message);

            return Ok(result);
        }
    }
}

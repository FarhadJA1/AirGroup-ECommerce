using A.Domain.Entities;
using B.Repository.UnitOfWork;
using C.Service.Abstractions;
using C.Service.Infrastructure.Dtos.Customer;
using C.Service.Infrastructure.Requests.Customer;
using C.Service.Infrastructure.Responses;
using C.Service.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace C.Service.Implementations;
public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PostResponse> CreateCustomerAsync(CreateCustomerReq input)
    {
        var customer = new Customer()
        {
            Firstname = input.Firstname,
            Gender = input.Gender,
            IsDeleted = false,
            Lastname = input.Lastname
        };

        await _unitOfWork.CustomerRepository.CreateCustomerAsync(customer);

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }

    public async Task<PostResponse> DeleteCustomerAsync(int id)
    {
        if (id <= 0) return new PostResponse(false, "Customer was not found");

        var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(id);

        if (customer is null) return new PostResponse(false, "Customer was not found");

        customer.IsDeleted = true;

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }

    public async Task<GetAllResponse<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = _unitOfWork.CustomerRepository.GetAllCustomersAsync();

        if (!customers.Any())
            return new GetAllResponse<CustomerDto>(false, "No customer was found");

        var result = await customers.Select(m => new CustomerDto()
        {
            Firstname = m.Firstname,
            Gender = m.Gender,
            Id = m.Id,
            Lastname = m.Lastname
        }).ToListAsync();

        return new GetAllResponse<CustomerDto>(true, result);
    }

    public async Task<PostResponse> UpdateCustomerAsync(UpdateCustomerReq input)
    {
        var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(input.Id);

        if (customer is null) return new PostResponse(false, "Customer was not found");

        if (InputHelper.IsInputProper(customer.Firstname, input.Firstname))
            customer.Firstname = input.Firstname;

        if (InputHelper.IsInputProper(customer.Lastname, input.Lastname))
            customer.Lastname = input.Lastname;

        if (customer.Gender != input.Gender)
            customer.Gender = input.Gender;

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);        
    }
}

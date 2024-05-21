using A.Domain.Entities;
using B.Repository.UnitOfWork;
using C.Service.Abstractions;
using C.Service.Infrastructure.Dtos.Order;
using C.Service.Infrastructure.Requests.Order;
using C.Service.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace C.Service.Implementations;
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PostResponse> CreateOrderAsync(CreateOrderReq input)
    {
        var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(input.CustomerId);

        if (customer is null) return new PostResponse(false, "Customer was not found");

        var order = new Order()
        {
            CreatedAt = DateTime.Now,
            OrderItems = new List<OrderItem>()
        };

        foreach (var orderItem in input.OrderItems)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(orderItem.ProductId);

            var validationResult = ValidateProducts(product!, orderItem);

            if (!validationResult.Succeeded)
                return new PostResponse(false, validationResult.Message);

            order.OrderItems.Add(new OrderItem()
            {
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                Order = order
            });

            product!.Stock -= orderItem.Quantity;
        }

        order.CustomerId = input.CustomerId;

        await _unitOfWork.OrderRepository.CreateOrderAsync(order);

        await _unitOfWork.SaveChangesAsync();

        return new PostResponse(true);
    }

    public async Task<GetAllResponse<OrderDto>> GetAllOrdersAsync()
    {
        var orders = _unitOfWork.OrderRepository.GetAllOrdersAsync();

        if (!orders.Any())
            return new GetAllResponse<OrderDto>(false, "No order was found");

        var result = await orders.Select(m => new OrderDto()
        {
            Id = m.Id,
            CreatedAt = m.CreatedAt.ToString("dd.MM.yyyy hh:mm"),
            Customer = new OrderCustomer()
            {
                Firstname = m.Customer.Firstname,
                Lastname = m.Customer.Lastname,
            },
            OrderItems = m.OrderItems.Select(x => new OrderItemDto()
            {
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity
            }).ToList(),
            TotalPrice = m.OrderItems.Sum(x => x.Product.Price * x.Quantity)
        }).ToListAsync();

        return new GetAllResponse<OrderDto>(true, result);
    }

    private PostResponse ValidateProducts(Product product, CreateOrderItemReq orderItem)
    {
        if (product is null) return new PostResponse(false, "Product was not found");

        if (orderItem.Quantity > product.Stock)
            return new PostResponse(false, $"{product.Name}: {product.Stock} items left in stock. Cannot order {orderItem.Quantity} item.");

        return new PostResponse(true);
    }
}

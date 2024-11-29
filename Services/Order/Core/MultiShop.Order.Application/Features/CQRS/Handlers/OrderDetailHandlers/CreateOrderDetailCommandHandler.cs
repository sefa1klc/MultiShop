using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommans;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            ProductID = command.ProductID,
            OrderingID = command.OrderingID,
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductAmount = command.ProductAmount,
            ProductTotalPrice = command.ProductTotalPrice,
        });
    }
}
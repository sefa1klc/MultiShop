using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommans;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var value = await _repository.GetByIdAsync(command.OrderDetailID);
        value.ProductPrice = command.ProductPrice;
        value.ProductID = command.ProductID;
        value.ProductName = command.ProductName;
        value.ProductTotalPrice = command.ProductTotalPrice;
        value.ProductAmount = command.ProductAmount;
        value.OrderingID = command.OrderingID;
        _repository.UpdateAsync(value);
    }
}
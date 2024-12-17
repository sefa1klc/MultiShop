using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.OrderingID);
        value.OrderDate = request.OrderDate;
        value.UserID = request.UserID;
        value.TotalPrice = request.TotalPrice;
        await _repository.UpdateAsync(value);
    }
}
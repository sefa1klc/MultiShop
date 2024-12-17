using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public CreateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            UserID = request.UserID,
            TotalPrice = request.TotalPrice,
            OrderDate = request.OrderDate,
        });
    }
}
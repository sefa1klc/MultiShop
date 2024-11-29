using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand command)
    {
        var value = await _repository.GetByIdAsync(command.AddressID);
        value.City = command.City;
        value.District = command.District;
        value.UserID = command.UserID;
        value.Detail = command.Detail;
        await _repository.UpdateAsync(value);
    }
}
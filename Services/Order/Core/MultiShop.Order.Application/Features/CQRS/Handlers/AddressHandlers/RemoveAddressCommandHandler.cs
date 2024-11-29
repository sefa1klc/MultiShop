using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public RemoveAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAddressCommand removeAddressCommand)
    {
        var value = await _repository.GetByIdAsync(removeAddressCommand.ID); 
        await _repository.DeleteAsync(value);
    }
}
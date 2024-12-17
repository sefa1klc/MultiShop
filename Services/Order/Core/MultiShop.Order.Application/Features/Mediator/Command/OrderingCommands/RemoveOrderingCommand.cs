using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;

public class RemoveOrderingCommand : IRequest
{
    public int OrderingID { get; set; }
    
    public RemoveOrderingCommand(int orderingId)
    {
        OrderingID = orderingId;
    }
}
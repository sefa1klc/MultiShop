using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;

public class CreateOrderingCommand : IRequest
{
    public string UserID { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
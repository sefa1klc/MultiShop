using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;

public class UpdateOrderingCommand :IRequest
{
    public int OrderingID { get; set; }
    public string UserID { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
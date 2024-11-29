namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommans;

public class RemoveOrderDetailCommand
{
    public int ID { get; set; }
    
    
    public RemoveOrderDetailCommand(int id)
    {
        ID = id;
    }
}
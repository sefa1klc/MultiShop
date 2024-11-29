namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommans;

public class CreateOrderDetailCommand
{
    public string ProductID { get; set; }   
    public int OrderingID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
}
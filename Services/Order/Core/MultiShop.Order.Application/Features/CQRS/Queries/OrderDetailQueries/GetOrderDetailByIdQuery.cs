namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

public class GetOrderDetailByIdQuery
{
    public int ID { get; set; }
    
    public GetOrderDetailByIdQuery(int id)
    {
        ID = id;
    }

}
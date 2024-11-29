namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

public class GetAddressByIdQuery
{
    public int ID { get; set; }
    
    public GetAddressByIdQuery(int id)
    {
        ID = id;
    }
}
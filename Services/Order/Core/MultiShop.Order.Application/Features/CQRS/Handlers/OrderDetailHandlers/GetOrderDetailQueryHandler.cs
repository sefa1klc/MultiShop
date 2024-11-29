using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults.OrderDetailResult;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return  values.Select(x => new GetOrderDetailQueryResult()
        {
            OrderDetailID = x.OrderDetailID,
            ProductID = x.ProductID,
            OrderingID = x.OrderingID,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            ProductAmount = x.ProductAmount,
            ProductTotalPrice = x.ProductTotalPrice
        }).ToList();
    }
}
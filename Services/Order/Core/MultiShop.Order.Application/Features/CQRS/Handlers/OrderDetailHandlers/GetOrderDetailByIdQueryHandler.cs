using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults.OrderDetailResult;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.ID);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailID = value.OrderDetailID,
            ProductID = value.ProductID,
            OrderingID = value.OrderingID,
            ProductName = value.ProductName,
            ProductPrice = value.ProductPrice,
            ProductAmount = value.ProductAmount,
            ProductTotalPrice = value.ProductTotalPrice
        };
    }
}
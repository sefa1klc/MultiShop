using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetAllAsync();
        return results.Select(x => new GetOrderingQueryResult
        {
            OrderingID = x.OrderingID,
            UserID = x.UserID,
            TotalPrice = x.TotalPrice,
            OrderDate = x.OrderDate
        }).ToList();
    }
}
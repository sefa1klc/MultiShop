using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIDQueryHandler : IRequestHandler<GetOrderingByIDQuery, GetOrderingByIDQueryResult>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingByIDQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderingByIDQueryResult> Handle(GetOrderingByIDQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.ID);
        return new GetOrderingByIDQueryResult
        {
           OrderingID = value.OrderingID,
           UserID = value.UserID,
           TotalPrice = value.TotalPrice,
           OrderDate = value.OrderDate,
        };
    }
}
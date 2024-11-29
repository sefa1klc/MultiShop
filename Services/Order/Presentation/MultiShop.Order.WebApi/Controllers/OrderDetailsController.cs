using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommans;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

    public OrderDetailsController(UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, 
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, 
        CreateOrderDetailCommandHandler createOrderDetailCommandHandler, 
        GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, 
        GetOrderDetailQueryHandler getOrderDetailQueryHandler)
    {
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var values = await _getOrderDetailQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrderDetailCommand command)
    {
        await _createOrderDetailCommandHandler.Handle(command);
        return Ok("Order Detail successfully created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateOrderDetailCommand command)
    {
        await _updateOrderDetailCommandHandler.Handle(command);
        return Ok("Order Detail successfully updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("Order Detail successfully removed");
    }
}
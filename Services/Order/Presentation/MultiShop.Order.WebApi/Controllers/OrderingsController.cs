using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderingsController : Controller
{
   private readonly IMediator _mediator;

   public OrderingsController(IMediator mediator)
   {
      _mediator = mediator;
   }

   [HttpGet]
   public async Task<IActionResult> GetAllAsync()
   {
      var values = await _mediator.Send(new GetOrderingQuery());
      return Ok(values);
   }
   
   [HttpGet("{id}")]
   public async Task<IActionResult> GetByIdAsync(int id)
   {
      var value = await _mediator.Send(new GetOrderingByIDQuery(id));
      return Ok(value);
   }

   [HttpPost]
   public async Task<IActionResult> CreateAsync(CreateOrderingCommand command)
   {
      await _mediator.Send(command);
      return Ok("Order successfully created");
   }

   [HttpPut]
   public async Task<IActionResult> UpdateAsync(UpdateOrderingCommand command)
   {
      await _mediator.Send(command);
      return Ok("Order successfully updated");
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteAsync(int id)
   {
      await _mediator.Send(new RemoveOrderingCommand(id));
      return Ok("Order successfully deleted");
   }
}
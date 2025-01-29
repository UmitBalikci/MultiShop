using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Orderings()
        {
            var result = await _mediator.Send(new GetOrderingQuery());

            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOrderingByID(Guid id)
        {
            var result = await _mediator.Send(new GetOrderingByIDQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);

            return Ok("Sipariş ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);

            return Ok("Sipariş güncelleme işlemi başarılı!");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOrdering(Guid id)
        {
            await _mediator.Send(new DeleteOrderingCommand(id));

            return Ok("Sipariş silme işlemi başarılı!");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIDQueryHandler _getOrderDetailByIDQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIDQueryHandler getOrderDetailByIDQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
            DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIDQueryHandler = getOrderDetailByIDQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            var result = await _getOrderDetailQueryHandler.Hadndle();

            return Ok(result);
        }

        [HttpGet("{Guid:id}")]
        public async Task<IActionResult> GetOrderDetailByID(Guid id)
        {
            var result = await _getOrderDetailByIDQueryHandler.Handle(new GetOrderDetailByIDQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);

            return Ok("Order Detail ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);

            return Ok("Order Detail güncelleme işlemi başarılı!");
        }

        [HttpDelete("{Guid:id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));

            return Ok("Order Detail silme işlemi başarılı!");
        }
    }
}

using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class DeleteOrderingCommand : IRequest
    {
        public Guid OrderingID { get; set; }

        public DeleteOrderingCommand(Guid orderingID)
        {
            OrderingID = orderingID;
        }
    }
}

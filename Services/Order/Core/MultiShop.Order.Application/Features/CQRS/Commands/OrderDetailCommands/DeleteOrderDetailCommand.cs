namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public Guid OrderDetailID { get; set; }

        public DeleteOrderDetailCommand(Guid orderDetailID)
        {
            OrderDetailID = orderDetailID;
        }
    }
}

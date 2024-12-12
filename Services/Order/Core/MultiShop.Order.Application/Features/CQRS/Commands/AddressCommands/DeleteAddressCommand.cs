namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public Guid AddressID { get; set; }

        public DeleteAddressCommand(Guid addressID)
        {
            AddressID = addressID;
        }
    }
}

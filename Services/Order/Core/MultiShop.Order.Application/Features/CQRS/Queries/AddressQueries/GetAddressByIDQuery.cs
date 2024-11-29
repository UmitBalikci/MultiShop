namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIDQuery
    {
        public Guid AddressID { get; set; }

        public GetAddressByIDQuery(Guid addressID)
        {
            AddressID = addressID;
        }
    }
}

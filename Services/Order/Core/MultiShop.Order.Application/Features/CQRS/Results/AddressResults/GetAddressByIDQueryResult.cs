namespace MultiShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressByIDQueryResult
    {
        public Guid AddressID { get; set; }
        public Guid? UserID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}

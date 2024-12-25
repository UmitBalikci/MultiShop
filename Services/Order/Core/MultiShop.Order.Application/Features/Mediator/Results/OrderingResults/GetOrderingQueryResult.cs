namespace MultiShop.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingQueryResult
    {
        public Guid OrderingID { get; set; }
        public Guid? UserID { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIDQuery
    {
        public Guid OrderDetailID { get; set; }

        public GetOrderDetailByIDQuery(Guid orderDetailID)
        {
            OrderDetailID = orderDetailID;
        }
    }
}

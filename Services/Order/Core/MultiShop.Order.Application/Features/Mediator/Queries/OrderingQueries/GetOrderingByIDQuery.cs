using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIDQuery : IRequest<GetOrderingByIDQueryResult>
    {
        public Guid OrderingID { get; set; }

        public GetOrderingByIDQuery(Guid orderingID)
        {
            OrderingID = orderingID;
        }
    }
}

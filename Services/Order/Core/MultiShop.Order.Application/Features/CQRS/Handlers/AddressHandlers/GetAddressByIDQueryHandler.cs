using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIDQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIDQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIDQueryResult> Handle(GetAddressByIDQuery query)
        {
            var value = await _repository.GetByIDAsync(query.AddressID);

            return new GetAddressByIDQueryResult
            {
                AddressID = value.AddressID,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                UserID = value.UserID,
            };
        }
    }
}

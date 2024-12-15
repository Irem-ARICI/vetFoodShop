using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using vetFoodShop.Order.Application.Features.CQRS.Results.AddressResults;
using vetFoodShop.Order.Application.Interfaces;
using vetFoodShop.Order.Domain.Entities;

namespace vetFoodShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId,
            };
        }
    }
}

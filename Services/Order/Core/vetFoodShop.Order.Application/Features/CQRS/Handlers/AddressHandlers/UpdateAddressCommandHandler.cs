using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using vetFoodShop.Order.Application.Interfaces;
using vetFoodShop.Order.Domain.Entities;

namespace vetFoodShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}

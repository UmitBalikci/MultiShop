using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesConroller : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIDQueryHandler _getAddressByIDQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;

        public AddressesConroller(GetAddressQueryHandler getAddressQueryHandler,
            GetAddressByIDQueryHandler getAddressByIDQueryHandler,
            CreateAddressCommandHandler createAddressCommandHandler,
            UpdateAddressCommandHandler updateAddressCommandHandler,
            DeleteAddressCommandHandler deleteAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIDQueryHandler = getAddressByIDQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Addresses()
        {
            var result = await _getAddressQueryHandler.Handle();

            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAddressByID(Guid id)
        {
            var result = await _getAddressByIDQueryHandler.Handle(new GetAddressByIDQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);

            return Ok("Adres ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);

            return Ok("Adres güncelleme işlemi başarılı!");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));

            return Ok("Adres silme işlemi başarılı!");
        }
    }
}

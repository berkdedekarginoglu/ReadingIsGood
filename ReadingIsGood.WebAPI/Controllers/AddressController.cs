using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("add")]
        public IActionResult AddAddress(AddAddressDto addAddressDto)
        {
            var result = _addressService.Add(addAddressDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetAddressesByUserId(string userId)
        {
            var result = _addressService.GetByUserId(userId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

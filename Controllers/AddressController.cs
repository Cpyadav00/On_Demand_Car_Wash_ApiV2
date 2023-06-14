using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService addressService;
        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }
        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            var temp = await addressService.GetAllAddress();
            return   Ok(temp);
        }
        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress(int id)
        {
            return Ok(await addressService.GetAddress(id));
        }
        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress(Address address)
        {
            return Ok(await addressService.AddAddress(address));
        }
        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(Address address)
        {
            return Ok(await addressService.UpdateAddress(address));
        }
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            return Ok(await addressService.DeleteAddress(id));
        }
    }
}

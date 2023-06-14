using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarService carService;
        public CarController(CarService _carService)
        {
            carService = _carService;
        }
        [HttpGet("GetAllCar")]
        public async Task<IActionResult> GetAllCar()
        {
            var cars = await carService.GetAllCar();
            return Ok(cars);
        }
        [HttpGet("GetCar")]
        public async Task<IActionResult> GetCar(int id)
        {
            return Ok(await carService.GetCar(id));
        }
        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(Car car)
        {
            return Ok(await carService.AddCar(car));
        }
        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            return Ok(await carService.UpdateCar(car));
        }
        [HttpDelete("DeleteCar/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            return Ok(await carService.DeleteCar(id));
        }
    }
}

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
        public async Task<ActionResult<List<Car>>> GetAllCar()
        {
            var cars = await carService.GetAllCar();
            return Ok(cars);
        }
        [HttpGet("GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            return Ok(await carService.GetCar(id));
        }
        [HttpPost("AddCar")]
        public async Task<ActionResult<bool>> AddCar(Car car)
        {
            return Ok(await carService.AddCar(car));
        }
        [HttpPut("UpdateCar")]
        public async Task<ActionResult<bool>> UpdateCar(Car car)
        {
            return Ok(await carService.UpdateCar(car));
        }
        [HttpDelete("DeleteCar/{id}")]
        public async Task<ActionResult<bool>> DeleteCar(int id)
        {
            return Ok(await carService.DeleteCar(id));
        }
    }
}

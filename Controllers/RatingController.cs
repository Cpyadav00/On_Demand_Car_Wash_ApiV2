using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private RatingService ratingService;
        public RatingController(RatingService _ratingService)
        {
           ratingService = _ratingService;
        }
        [HttpGet("GetAverageRating/{id}")]
        public async Task<IActionResult> GetAverageRating(int id)
        {
            return Ok(await ratingService.GetAverageRating(id));
        }
        [HttpPost("AddRating")]
        public async Task<IActionResult> AddRating(Rating rate)
        {
            return Ok(await ratingService.AddRating(rate));
        }
        [HttpPut("UpdateRating")]
        public async Task<IActionResult> UpdateRating(Rating rate)
        {
            return Ok(await ratingService.UpdateRating(rate));
        }
        [HttpDelete("DeleteRating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            return Ok(await ratingService.DeleteRating(id));
        }
    }
}

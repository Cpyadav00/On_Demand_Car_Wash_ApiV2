using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private SubscriberService subscriberService;
        public SubscriberController(SubscriberService _subscriberService)
        {
            subscriberService = _subscriberService;
        }
        [HttpGet("GetAllSubscriber")]
        public async Task<IActionResult> GetAllSubscriber()
        {
            var subscriber = await subscriberService.GetAllSubscriber();
            return Ok(subscriber);
        }
        [HttpGet("GetSubscriber/{id}")]
        public async Task<IActionResult> GetSubscriber(int id)
        {
            return Ok(await subscriberService.GetSubscriber(id));
        }
        [HttpPost("AddSubscriber")]
        public async Task<IActionResult> AddSubscriber(Subscriber subscriber)
        {
            return Ok(await subscriberService.AddSubscriber(subscriber));
        }
        [HttpPut("UpdateSubscriber")]
        public async Task<IActionResult> UpdateSubscriber(Subscriber subscriber)
        {
            return Ok(await subscriberService.UpdateSubscriber(subscriber));
        }
        [HttpDelete("DeleteSubscriber/{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            return Ok(await subscriberService.DeleteSubscriber(id));
        }
    }
}

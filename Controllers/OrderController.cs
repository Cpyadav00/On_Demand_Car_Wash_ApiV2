using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;
using System.Data;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController(OrderService _orderService)
        {
            orderService = _orderService;
        }
       // [Authorize(Roles = "Washer")]
        [HttpGet("GetAllOrder")]
        public async Task<ActionResult<List<Order>>> GetAllOrder()
        {
            var temp=await orderService.GetAllOrder();
            return Ok(temp);
        }
        [HttpGet("GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return Ok(await orderService.GetOrder(id));
        }
        [HttpPost("AddOrder")]
        public async Task<ActionResult<bool>> AddOrder(Order order)
        {
            return Ok(await orderService.AddOrder(order));
        }
        [HttpPut("UpdateOrder")]
        public async Task<ActionResult<bool>> UpdateOrder(Order admin)
        {
            return Ok(await orderService.UpdateOrder(admin));
        }
        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            return Ok(await orderService.DeleteOrder(id));
        }
    }
}

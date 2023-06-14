using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllDataAtOnePlace : ControllerBase
    {
        private readonly OrderSendingDataService service;
         public AllDataAtOnePlace(OrderSendingDataService serv)
        {
            service = serv;
                
        }


        [HttpGet]
        [Route("AllData")]
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await service.GetAllDetails());
        }
    }
}

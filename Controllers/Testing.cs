using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testing : Controller
    {
        private readonly CarDbContext _context;
        public Testing(CarDbContext context)
        {
                _context = context;
        }
        [HttpPost]
        [Route("Postdata")]
        public ActionResult<int> Postdata(Car obj)
        {
            int id=0;
            if (obj == null)
            {
                return id;
            }
            _context.Cars.Add(obj);
            _context.SaveChanges();
            id=obj.Id;
           return id; 
        }
    }
}

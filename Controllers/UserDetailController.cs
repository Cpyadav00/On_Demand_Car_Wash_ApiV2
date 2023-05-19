using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UserDetailService service; 
        public UserDetailController(UserDetailService ser)
        {
            service = ser;     
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDetailDTO user)
        {
           var result= await service.Login(user);
            if(result==200)
            {
                return Ok(new { Message = "Login Successful" });
            }
            else if(result==400)
            {
                return BadRequest(new {Message="User Not found"});
            }
            else if (result == 401)
            {
                return BadRequest(new { Message = "Password is not correct" });
            }
            else if (result == 404)
            {
                return BadRequest(new { Message = "Object is Null" });
            }
            else
            return BadRequest();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserDetail user)
        {

            var result = await service.Register(user);
            if (result == 200)
            {
                return Ok(new {Message= "User Registered" });
            }
            else if(result==800)
            {
                return BadRequest(new { Message = "Password is Not Valid" });
            }
            else if(result==409)
            {
                return BadRequest(new { Message = "Email already Exist!" });
            }
            else if(result==404)
            {
                return BadRequest(new { Message = "User is Null!" });
            }
            else
            {
                return BadRequest();
            }
        }

    }
}

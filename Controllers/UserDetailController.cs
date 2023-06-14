using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.Helpers;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UserDetailService service; 
        private readonly TokenGeneration token;
        public UserDetailController(UserDetailService ser)
        {
            service = ser;     
        }

        #region Login User

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDetail user)
        {
           var result= await service.Login(user);
            if(result.ReturnCode==200)
            {
                //user.Token = ;
                return Ok(new {Token = result.Token, Message = "Login Successful" });
            }
            else if(result.ReturnCode == 400)
            {
                return BadRequest(new {Message="User Not found"});
            }
            else if (result.ReturnCode == 401)
            {
                return BadRequest(new { Message = "Password is not correct" });
            }
            else if (result.ReturnCode == 404)
            {
                return BadRequest(new { Message = "Object is Null" });
            }
            else
            return BadRequest();
        }


        #endregion Login User


        #region For Register User

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserDetail user)
        {

            var result = await service.Register(user);
            if (result.ReturnCode == 200)
            {
                return Ok(new {Message= "User Registered" });
            }
            else if(result.ReturnCode ==800)
            {
                return BadRequest(new { Message = "Password is Not Valid" });
            }
            else if(result.ReturnCode ==409)
            {
                return BadRequest(new { Message = "Email already Exist!" });
            }
            else if(result.ReturnCode ==404)
            {
                return BadRequest(new { Message = "User is Null!" });
            }
            else
            {
                return BadRequest();
            }
        }


        #endregion For Register User


        #region For Deleting User

        [HttpDelete]
       // [Authorize(Roles = "Admin")]
        [Route("DeleteUserDetails/{id}")]
        public async Task<IActionResult> DeleteUserDetails([FromRoute]int id)
        {
            if (id == 0)
                return Ok(false);
            if(await service.DeleteUserDetails(id))
                return Ok(true);
            return Ok(false);
        }

        #endregion For Deleting User

        #region For Getting All Users

        [HttpGet]
       // [Authorize(Roles ="Admin")]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            var result = await service.GetUserDetails();
            return Ok(result);
        }

        #endregion For Getting All Users


    }
}

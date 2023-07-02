using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private ContactUsService ContactUsService; 
        public ContactUsController(ContactUsService _ContactUsService)
        { 
            ContactUsService = _ContactUsService;
        }
        [HttpGet("GetAllContactUs")]
        public async Task<IActionResult> GetAllContactUs()
        {
            var contactus = await ContactUsService.GetAllContactUs();
            return Ok(contactus);
        }
        [HttpGet("GetContactUs/{id}")]
        public async Task<IActionResult> GetContactUs(int id)
        {
            return Ok(await ContactUsService.GetContactUs(id));
        }
        [HttpPost("AddContactUs")]
        public async Task<IActionResult> AddContactUs(ContactUs contactus)
        {
            return Ok(await ContactUsService.AddContactUs(contactus));
        }
        [HttpPut("UpdateContactUs")]
        public async Task<IActionResult> UpdateContactUs(ContactUs contactus)
        {
            return Ok(await ContactUsService.UpdateContactUs(contactus));
        }
        [HttpDelete("DeleteContactUs/{id}")]
        public async Task<IActionResult> DeleteContactUs(int id)
        {
            return Ok(await ContactUsService.DeleteContactUs(id));
        }
    }
}

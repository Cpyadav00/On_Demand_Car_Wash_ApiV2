using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private EmailService emailService;
        public EmailController(EmailService _emailService)
        {
            emailService = _emailService;
        }
        [HttpGet("SendEmailAsync")]
        public async Task<IActionResult> SendEmailAsync(string email, string subject, string message)
        {
            await emailService.SendEmailAsync(email, subject, message);
            return Ok();
        }

        [HttpPost("RestPasswordMail")]
        public async Task<bool> RestPasswordMail(EmailDTO email)
        {
            
            var ans= await emailService.RestPasswordMail(email);
            return ans;
        }


        [HttpGet("GenerateAndSendInvoice/{id}")]
        public async Task<IActionResult> GenerateAndSendInvoice(int id)
        {
            await emailService.GenerateAndSendInvoice(id);
            return Ok();
        }

    }
}

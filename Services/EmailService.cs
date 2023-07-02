using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class EmailService
    {
        private IEmail _iemail;
        public EmailService(IEmail iemail)
        {
            _iemail = iemail;
        }
        public   Task SendEmailAsync(string email, string subject, string message)
        {
            return  _iemail.SendEmailAsync(email,subject,message);
        }

        public  Task<bool> RestPasswordMail(EmailDTO recipientEmail)
        {
            return  _iemail.RestPasswordMail(recipientEmail);
        }

        public async Task GenerateAndSendInvoice(int id)
            => await _iemail.GenerateAndSendInvoice(id);
    }
}

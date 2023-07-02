using On_Demand_Car_Wash_ApiV2.DTOs;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IEmail
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task GenerateAndSendInvoice(int id);
        Task<bool> RestPasswordMail(EmailDTO recipientEmail);
    }
}

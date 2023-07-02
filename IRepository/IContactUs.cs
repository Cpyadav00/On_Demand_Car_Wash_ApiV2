using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IContactUs
    {
        Task<List<ContactUs>> GetAllContactUs();
        Task<ContactUs> GetContactUs(int id);
        Task<int> AddContactUs(ContactUs contactUs);
        Task<bool> UpdateContactUs(ContactUs contactUs);
        Task<bool> DeleteContactUs(int id);
    }
}

using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class ContactUsService
    {
    private IContactUs _IContactus;  
    public ContactUsService(IContactUs icontact)
    {
            _IContactus = icontact;
    }
    public async Task<List<ContactUs>> GetAllContactUs()
    {
        return await _IContactus.GetAllContactUs();
    }
    public async Task<ContactUs> GetContactUs(int id)
    {
        return await _IContactus.GetContactUs(id);
    }
    public async Task<int> AddContactUs(ContactUs contactus)
    {
        return await _IContactus.AddContactUs(contactus);
    }
    public async Task<bool> UpdateContactUs(ContactUs contactus)
    {
        return await _IContactus.UpdateContactUs(contactus);
    }
    public async Task<bool> DeleteContactUs(int id)
    {
        return await _IContactus.DeleteContactUs(id);
    }
}
}

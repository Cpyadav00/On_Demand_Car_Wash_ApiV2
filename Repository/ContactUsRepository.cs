using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class ContactUsRepository : IContactUs
    {
        private CarDbContext _carDb;
        public ContactUsRepository(CarDbContext carDbContext)
        {
            _carDb = carDbContext;
        }

        #region Adding ContactUs   
        public async Task<int> AddContactUs(ContactUs contactUs)
        {
            try
            {
                int id = 0;
                if (contactUs == null)
                {
                    return id;
                }
                await _carDb.ContactUss.AddAsync(contactUs);
                await _carDb.SaveChangesAsync();
                id = contactUs.Id;
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding ContactUs

        #region Delete ContactUs
        public async Task<bool> DeleteContactUs(int id)
        {
            try
            {
                var contactUs = await _carDb.ContactUss.FindAsync(id);
                if (contactUs == null)
                    return false;
                _carDb.ContactUss.Remove(contactUs);
                await _carDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete ContactUs

        #region GetAll ContactUs
        public async Task<List<ContactUs>> GetAllContactUs()
        {
            try
            {
                var contactUs = await _carDb.ContactUss.ToListAsync();
                return contactUs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll ContactUs

        #region Get ContactUs
        public async Task<ContactUs> GetContactUs(int id)
        {
            ContactUs contactUs;
            try
            {
                contactUs = await _carDb.ContactUss.FindAsync(id);
                if (contactUs != null)
                {
                    return contactUs;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return contactUs;
        }
        #endregion Get ContactUs

        #region Update ContactUs
        public async Task<bool> UpdateContactUs(ContactUs contactUs)
        {
            try
            {
                var presentcontactUs = await _carDb.ContactUss.AsNoTracking().FirstOrDefaultAsync(u => u.Id == contactUs.Id);
                if (presentcontactUs == null)
                    return false;
                _carDb.ContactUss.Update(contactUs);
                await _carDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update ContactUs
    }
}

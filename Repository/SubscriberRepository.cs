using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class SubscriberRepository: ISubscriber
    {
        private CarDbContext _carDb;
        public SubscriberRepository(CarDbContext carDbContext)
        {
            _carDb = carDbContext;
        }

        #region Adding Subscriber  
        public async Task<int> AddSubscriber(Subscriber subscriber)
        {
            try
            {
                int id = 0;
                if (subscriber == null)
                {
                    return id;
                }
                await _carDb.Subscribers.AddAsync(subscriber);
                await _carDb.SaveChangesAsync();
                id = subscriber.Id;
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Subscriber

        #region Delete Subscriber
        public async Task<bool> DeleteSubscriber(int id)
        {
            try
            {
                var subscriber = await _carDb.Subscribers.FindAsync(id);
                if (subscriber == null)
                    return false;
                _carDb.Subscribers.Remove(subscriber);
                await _carDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Subscriber

        #region GetAll Subscriber
        public async Task<List<Subscriber>> GetAllSubscriber()
        {
            try
            {
                var subscriber = await _carDb.Subscribers.ToListAsync();
                return subscriber;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Subscriber

        #region Get Subscriber
        public async Task<Subscriber> GetSubscriber(int id)
        {
            Subscriber subscriber;
            try
            {
                subscriber = await _carDb.Subscribers.FindAsync(id);
                if (subscriber != null)
                {
                    return subscriber;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return subscriber;
        }
        #endregion Get Subscriber

        #region Update Subscriber
        public async Task<bool> UpdateSubscriber(Subscriber subscriber)
        {
            try
            {
                var presentSubscriber = await _carDb.Subscribers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == subscriber.Id);
                if (presentSubscriber == null)
                    return false;
                _carDb.Subscribers.Update(subscriber);
                await _carDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Subscriber
    }
}

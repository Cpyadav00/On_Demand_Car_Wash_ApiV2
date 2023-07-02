using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class SubscriberService
    {
        private ISubscriber _ISubscriber;
        public SubscriberService(ISubscriber iSubscriber)
        {
            _ISubscriber = iSubscriber;
        }
        public async Task<List<Subscriber>> GetAllSubscriber()
        {
            return await _ISubscriber.GetAllSubscriber();
        }
        public async Task<Subscriber> GetSubscriber(int id)
        {
            return await _ISubscriber.GetSubscriber(id);
        }
        public async Task<int> AddSubscriber(Subscriber subscriber)
        {
            return await _ISubscriber.AddSubscriber(subscriber);
        }
        public async Task<bool> UpdateSubscriber(Subscriber subscriber)
        {
            return await _ISubscriber.UpdateSubscriber(subscriber);
        }
        public async Task<bool> DeleteSubscriber(int id)
        {
            return await _ISubscriber.DeleteSubscriber(id);
        }
    }
}

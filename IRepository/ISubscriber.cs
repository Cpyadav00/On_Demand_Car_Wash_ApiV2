using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface ISubscriber
    {
        Task<List<Subscriber>> GetAllSubscriber();
        Task<Subscriber> GetSubscriber(int id);
        Task<int> AddSubscriber(Subscriber subscriber);
        Task<bool> UpdateSubscriber(Subscriber subscriber);
        Task<bool> DeleteSubscriber(int id);
    }
}

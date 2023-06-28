using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrder();
        Task<List<Order>> AllPreviousOrder(int id);
        
            Task<List<Order>> AllPreviousOrderForCustomer(int id);
        
             Task<List<Order>> ScheduledWashForCustomer(int id);

        
            Task<List<Order>> AllDeliveredOrderForAdmin();



        Task<List<Order>> GetAllRequest();
        Task<List<Order>> ScheduledWash(int id);
        
        Task<Order> GetOrder(int id);
         Task<Order> AddOrder(Order order);
         Task<bool> UpdateOrder(Order order);
         Task<bool> DeleteOrder(int id);
    }
}

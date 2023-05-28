using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrder(int id);
         Task<bool> AddOrder(Order order);
         Task<bool> UpdateOrder(Order order);
         Task<bool> DeleteOrder(int id);
    }
}

using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class OrderSendingDataService
    {
        private readonly IOrderSendingData repo;

        public OrderSendingDataService(IOrderSendingData _repo)
        {
            repo = _repo;       
        }
        public async Task<List<OrderSendingData>> GetAllDetails()
        {
            return await repo.GetAllDetails();

        }
    }
}

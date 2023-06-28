using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class PaymentService
    {
        
        private IPayment _ICar;
        public PaymentService(IPayment Icar)
        {
            _ICar = Icar;
        }
        public async Task<List<Payment>> GetAllPayment()
        {
            return await _ICar.GetAllPayment();
        }
        public async Task<Payment> GetPayment(int id)
        {
            return await _ICar.GetPayment(id);
        }
        public async Task<int> AddPayment(Payment car)
        {
            return await _ICar.AddPayment(car);
        }
        public async Task<bool> UpdatePayment(Payment car)
        {
            return await _ICar.UpdatePayment(car);
        }
        public async Task<bool> DeletePayment(int id)
        {
            return await _ICar.DeletePayment(id);
        }
    }
}

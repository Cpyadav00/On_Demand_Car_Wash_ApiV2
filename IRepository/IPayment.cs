using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IPayment
    {

            Task<List<Payment>> GetAllPayment();
            Task<Payment> GetPayment(int id);
            Task<int> AddPayment(Payment car);
            Task<bool> UpdatePayment(Payment car);
            Task<bool> DeletePayment(int id);

}
}

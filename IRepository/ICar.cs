using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface ICar
    {
        Task<List<Car>> GetAllCar();
        Task<Car> GetCar(int id);
         Task<int> AddCar(Car car);
         Task<bool> UpdateCar(Car car);
         Task<bool> DeleteCar(int id);
    }
}

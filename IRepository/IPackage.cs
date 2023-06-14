using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IPackage
    {
        Task<List<Package>> GetAllPackage();
        Task<Package> GetPackage(int id);
         Task<int> AddPackage(Package package);
         Task<bool> UpdatePackage(Package package);
         Task<bool> DeletePackage(int id);
    }
}

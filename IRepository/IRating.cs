using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IRating
    {
        Task<double> GetAverageRating(int id);
        Task<int> AddRating(Rating rate);
        Task<bool> UpdateRating(Rating rate);
        Task<bool> DeleteRating(int id);
    }
}

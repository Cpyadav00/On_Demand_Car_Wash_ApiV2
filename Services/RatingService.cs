using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class RatingService
    {
        private IRating _irating;
        public RatingService(IRating irating)
        {
            _irating = irating;
        }
        public async Task<double> GetAverageRating(int id)
        {
            return await _irating.GetAverageRating(id);
        }
        public async Task<int> AddRating(Rating rating)
        {
            return await _irating.AddRating(rating);
        }
        public async Task<bool> UpdateRating(Rating rating)
        {
            return await _irating.UpdateRating(rating);
        }
        public async Task<bool> DeleteRating(int id)
        {
            return await _irating.DeleteRating(id);
        }

    }
}

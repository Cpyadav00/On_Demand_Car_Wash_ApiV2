using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Repository;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class UserDetailService
    {
        public readonly IUserDetail inter;
        public UserDetailService(IUserDetail repository)
        {
            inter = repository; 
        }

        public async Task<int> Login(UserDetailDTO user)
        {
            return await inter.Login(user);
        }

        public async Task<int> Register(UserDetail user)
        {
            return await inter.Register(user);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IUserDetail
    {
        Task<CustomReturnType> Login(UserDetail user);
        Task<CustomReturnType> Register(UserDetail user);
        Task<List<UserDetail>> GetUserDetails();

    }
}

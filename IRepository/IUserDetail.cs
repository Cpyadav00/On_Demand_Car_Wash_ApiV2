using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IUserDetail
    {
        Task<int> Login(UserDetailDTO user);
        Task<int> Register(UserDetail user);
    }
}

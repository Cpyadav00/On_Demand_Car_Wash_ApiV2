using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IUserDetail
    {
        Task<CustomReturnType> Login(LoginDTO user);
        Task<CustomReturnType> Register(UserDetail user);
        Task<List<UserDetail>> GetUserDetails();
        Task<List<UserDetail>> GetWasherDetails();
        Task<List<UserDetail>> GetCustomers();
        Task<List<UserDetail>> GetAdmins();

        Task<bool> DeleteUserDetails(int id);

        Task<UserDetailDTO> GetUserById(int id);
        
            Task<int> UpdateUser(UserDetailDTO obj);

    }
}


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

        public async Task<CustomReturnType> Login(UserDetail user)
        {
            return await inter.Login(user);
        }

        public async Task<CustomReturnType> Register(UserDetail user)
        {
            return await inter.Register(user);
        }

        public async Task<List<UserDetail>>  GetUserDetails()
        {
            return await inter.GetUserDetails();
        }

        

        public async Task<List<UserDetail>> GetWasherDetails()
        {
            return await inter.GetWasherDetails();
        }

        public async Task<List<UserDetail>> GetAdmins()
        {
            return await inter.GetAdmins();
        }

        public async Task<List<UserDetail>> GetCustomers()
        {
            return await inter.GetCustomers();
        }

        public async Task<bool> DeleteUserDetails(int id)
        {
            return await inter.DeleteUserDetails(id);
        }

        public async Task<UserDetailDTO> GetUserById(int id)
        {
            return await inter.GetUserById(id);
        }

        public async Task<int> UpdateUser(UserDetailDTO obj)
        {
            return await inter.UpdateUser(obj);
        }

    }
}

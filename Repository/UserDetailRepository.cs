using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.Helpers;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class UserDetailRepository : IUserDetail
    {
        private readonly CarDbContext context;
        private  TokenGeneration token=new TokenGeneration();
        public UserDetailRepository(CarDbContext _context)
        {
            context = _context; 
        }

        #region Login User
        public async Task<CustomReturnType> Login(LoginDTO user)
        {
            try
            {
                CustomReturnType ans = new CustomReturnType();
                if (user == null)
                {
                    ans.ReturnCode = 404;

                    return ans;
                   
                }

                var check=await context.UserDetails.FirstOrDefaultAsync(
                    x=>x.Email == user.Email);
                if (check != null) {

                    if (PasswordHasher.VerifyPassword(user.Password, check.Password))
                    {
                        check.Token = token.CreateJwt(check);
                        ans.ReturnCode = 200;
                        ans.Token = check.Token;
                        context.SaveChanges();  
                        return ans;
                    }
                    ans.ReturnCode = 400;
                    return ans;
                }
                else
                {
                    ans.ReturnCode = 400;
                    return ans;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion Login User

         #region Deleting User

        public async Task<bool> DeleteUserDetails(int id)
        {
            try
            {
                var obj = await context.UserDetails.FirstOrDefaultAsync(x=>x.UserId==id);
                if (obj == null)
                    return false;
                context.UserDetails.Remove(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

           #endregion Deleting User


        #region For Register User
        public async Task<CustomReturnType> Register(UserDetail user)
        {
            try
            {
                CustomReturnType ans = new CustomReturnType();
                if (user != null)
                {
                    //check email
                    if(await CheckEmailExistAsync(user.Email))
                    {
                        ans.ReturnCode = 409;
                        return ans;
                    }
                    //check password strength
                    var pass = CheckPasswordStrength(user.Password);
                    if(!string.IsNullOrEmpty(pass))
                    {
                        ans.ReturnCode = 800;
                        return ans;
                    }
                    user.Password=PasswordHasher.HashPassword(user.Password);
                   // user.Role = "Customer";
                    await context.UserDetails.AddAsync(user);
                    await context.SaveChangesAsync();
                    ans.ReturnCode = 200;
                    return ans;
                }

                else
                {
                    ans.ReturnCode = 404;
                    return ans;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion For Register User 


        #region For Checking Email Is Present Or Not

        private async Task<bool> CheckEmailExistAsync(string email)
    => await context.UserDetails.AnyAsync(x=>x.Email == email);


        #endregion For Checking Email Is Present Or Not


        #region For Checking PasswordStrength

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length<8)
                sb.Append("Minimum password length should be 8"+Environment.NewLine);
               
            if (!Regex.IsMatch(password, "[a-z]")
                    && Regex.IsMatch(password, "[A-Z]")
                    && Regex.IsMatch(password, "[0-9]") )
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
               
            if (!Regex.IsMatch(password, "[!,@,#,$,%,^,&,*,(,),{,},|,\\,<,>,?,/]"))
                    sb.Append("Password should contain special chars" + Environment.NewLine);
                return sb.ToString();
        }

        #endregion For Checking PasswordStrength


        #region For Getting All Users
        public async Task<List<UserDetail>> GetUserDetails()
        {
            return await context.UserDetails.ToListAsync();
        }


        #endregion For Getting All Users
        

        #region For Getting All Washer
        public async Task<List<UserDetail>> GetWasherDetails()
        {
            return await context.UserDetails.Where(u=>u.Role=="Washer").ToListAsync();

           

        }
        #endregion For Getting All Washer

        #region For Getting All Customers
        public async Task<List<UserDetail>> GetCustomers()
        {
            return await context.UserDetails.Where(u => u.Role == "Customer").ToListAsync();



        }
        #endregion For Getting All Customers


        #region For Getting All Admins
        public async Task<List<UserDetail>> GetAdmins()
        {
            return await context.UserDetails.Where(u => u.Role == "Admin").ToListAsync();



        }
        #endregion For Getting All Admins



        #region For Getting Users By Id
        public async Task<UserDetailDTO> GetUserById(int id)
        {
            UserDetail user;
            UserDetailDTO userDetailDTO=new UserDetailDTO();
            try
            {
                user = await context.UserDetails.FindAsync(id);
                if (user != null)
                {
                    userDetailDTO.FirstName = user.FirstName;
                    userDetailDTO.LastName = user.LastName; 
                    userDetailDTO.Email = user.Email;
                    userDetailDTO.Gender = user.Gender;
                    userDetailDTO.Role = user.Role;
                    userDetailDTO.PhoneNumber = user.PhoneNumber;
                    userDetailDTO.PermanentAddress= user.PermanentAddress;
                    userDetailDTO.Age = user.Age;
                    userDetailDTO.Id = user.UserId;
                    return userDetailDTO;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return userDetailDTO;
        }


        #endregion For Getting Users By Id





        #region For Update User
        public async Task<int> UpdateUser(UserDetailDTO userDetailDTO)
        {
            UserDetail user= await context.UserDetails.FindAsync(userDetailDTO.Id);
            //UserDetailDTO userDetailDTO = new UserDetailDTO();
            try
            {
                if (user != null)
                {
                   user.FirstName = userDetailDTO.FirstName;
                    user.LastName = userDetailDTO.LastName;
                    user.Email = userDetailDTO.Email;
                    user.Gender = userDetailDTO.Gender;
                    user.PhoneNumber = userDetailDTO.PhoneNumber;
                    user.Age = userDetailDTO.Age;
                    user.PermanentAddress = userDetailDTO.PermanentAddress;
                    context.UserDetails.Update(user);
                    await context.SaveChangesAsync();
                    return user.UserId;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return user.UserId;
        }


        #endregion For Update User



    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public UserDetailRepository(CarDbContext _context)
        {
            context = _context;    
        }
        public async Task<int> Login(UserDetailDTO user)
        {
            try
            {
                if (user == null)
                {
                    return 404;
                }

                var check=await context.UserDetails.FirstOrDefaultAsync(
                    x=>x.Email == user.Email);
                if (check != null) {
                    if(PasswordHasher.VerifyPassword(check.Password,user.Password))
                      return 200;

                    return 401;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception ex)
            {
                return 500;
            }
            finally {  }
        }

        public async Task<int> Register(UserDetail user)
        {
            try
            {
                if (user != null)
                {
                    //check email
                    if(await CheckEmailExistAsync(user.Email))
                    {
                        return 409;
                    }
                    //check password strength
                    var pass = CheckPasswordStrength(user.Password);
                    if(!string.IsNullOrEmpty(pass))
                    {
                        return 800;
                    }
                    user.Password=PasswordHasher.HashPassword(user.Password);
                    user.Role = "Customer";
                    await context.UserDetails.AddAsync(user);
                    await context.SaveChangesAsync();
                    return 200;
                }

                else
                {
                    return 404;
                }
            }
            catch (Exception ex)
            {
                return 500;
            }
            finally {  }
        }

   private async Task<bool> CheckEmailExistAsync(string email)
    => await context.UserDetails.AnyAsync(x=>x.Email == email);
 
        
     private  string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length<8)
                sb.Append("Minimum password length should be 8"+Environment.NewLine);
               
            if (!Regex.IsMatch(password, "[a-z]")
                    && Regex.IsMatch(password, "[A-Z]")
                    && Regex.IsMatch(password, "[0-9]") )
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
               
            if (!Regex.IsMatch(password, "[!,@,#,$,%,^,&,*,(,),{,},[,],|,\\,<,>,?,/]"))
                    sb.Append("Password should contain special chars" + Environment.NewLine);
                return sb.ToString();
        }


    }
}

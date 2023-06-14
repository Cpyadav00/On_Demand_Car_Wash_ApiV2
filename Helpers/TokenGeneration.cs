using Microsoft.IdentityModel.Tokens;
using On_Demand_Car_Wash_ApiV2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace On_Demand_Car_Wash_ApiV2.Helpers
{
    public class TokenGeneration
    {
      

        public string CreateJwt(UserDetail user)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("This is the secret key we will use to generate token for the project");
                
                //creating payload
                var identity = new ClaimsIdentity(new Claim[]
                    {
                    new Claim( ClaimTypes.Role,user.Role),
                    new Claim ( ClaimTypes.Name,$"{ user.FirstName} { user.LastName}"),
                    new Claim( ClaimTypes.PrimarySid,user.UserId.ToString())
                    });
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                return jwtTokenHandler.WriteToken(token);
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.DTOs
{
    public class UserDetailDTO
    {
        //[Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}

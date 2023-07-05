using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public string Gender { get; set; }

        public string PermanentAddress { get; set; }

        public int Age { get; set; }

    }
}

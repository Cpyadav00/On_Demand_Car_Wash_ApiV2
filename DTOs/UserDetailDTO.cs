using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.DTOs
{
    public class UserDetailDTO
    {
        public int WasherId { get; set; }
        public string WasherName { get; set; }

     //   [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

     //   [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Status { get; set; }
        public int RatingsOfWasher { get; set; }
       // public int OrderId { get; set; }
    }
}

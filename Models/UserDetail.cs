using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
       // [Required]
        public string FirstName { get; set; }
       // [Required]
        public string LastName { get; set; }
        //[Required]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
       // [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
      //  [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        public string Token { get; set; }
        //[Required]
        public bool Status { get; set; } = true;
       // [Required]
        public string Role { get; set; }
    }
}

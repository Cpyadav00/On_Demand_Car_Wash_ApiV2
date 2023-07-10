using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email must be between 1 and 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

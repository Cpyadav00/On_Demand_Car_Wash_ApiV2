using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone number.")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email must be between 1 and 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Token is required.")]
        public string Token { get; set; } = "empty";
        [Required(ErrorMessage = "Email is required.")]
        public string Status { get; set; } = "Active";
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = "empty";
        [Required(ErrorMessage = "PermanentAddress is required.")]
        public string PermanentAddress { get; set; } = "empty";
        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int Age { get; set; } = 0;
    }

}

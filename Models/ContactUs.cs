using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class ContactUs
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email must be between 1 and 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(500, ErrorMessage = "Message must be between 1 and 500 characters.")]
        public string Message { get; set; }
    }

}

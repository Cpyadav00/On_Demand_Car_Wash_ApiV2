using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Subscriber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email must be between 1 and 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "IsSubscribed is required.")]
        public bool IsSubscribed { get; set; } = true;
    }

}

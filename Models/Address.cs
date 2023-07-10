using On_Demand_Car_Wash_ApiV2.IRepository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Address
    {
        [Key]
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer address is required.")]
        [StringLength(100, ErrorMessage = "Customer address must be between 1 and 100 characters.")]
        public string CustAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City must be between 1 and 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State must be between 1 and 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pincode is required.")]
        [StringLength(10, ErrorMessage = "Pincode must be between 1 and 10 characters.")]
        public string Pincode { get; set; }

       [Required(ErrorMessage = "Country is required.")]
       [StringLength(50, ErrorMessage = "Country must be between 1 and 50 characters.")]
        public string Country { get; set; }

    }
}

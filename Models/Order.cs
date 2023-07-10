using On_Demand_Car_Wash_ApiV2.IRepository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Order
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(50, ErrorMessage = "Customer name must be between 1 and 50 characters.")]
        public string CustomerName { get; set; }

        public DateTime Date_Time { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total cost must be a positive value.")]
        public float TotalCost { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        [StringLength(500, ErrorMessage = "Status must be between 1 and 500 characters.")]
        public string Status { get; set; }

        public DateTime IsScheduledLater { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        [StringLength(500, ErrorMessage = "Instructions must be between 1 and 500 characters.")]
        public string Instructions { get; set; }
        [Required(ErrorMessage = "PaymentStatus is required.")]
        [StringLength(500, ErrorMessage = "PaymentStatus must be between 1 and 500 characters.")]
        public string PaymentStatus { get; set; } = "Not Paid";
        [Required(ErrorMessage = "PaymentId is required.")]
        public int PaymentId { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public double PhoneNumber { get; set; }

        [Required(ErrorMessage = "CustId is required.")]
        public int CustId { get; set; }
        [Required(ErrorMessage = "WasherId is required.")]
        public int WasherId { get; set; }

        [Required(ErrorMessage = "IsDisApprove is required.")]
        public bool IsDisApprove { get; set; } = false;

        [Required(ErrorMessage = "AddressId is required.")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        [Required(ErrorMessage = "PackageId is required.")]

        public int PackageId { get; set; }
        [Required(ErrorMessage = "CarId is required.")]

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }

}

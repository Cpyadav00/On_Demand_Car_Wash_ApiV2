using On_Demand_Car_Wash_ApiV2.IRepository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Order
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public float TotalCost { get; set; }
        public string Status { get; set; }
        public string IsScheduledLater { get; set; }
        public string Instructions { get; set; }
        public string PaymentStatus { get; set; }


        public int? CustId { get; set; }
        [ForeignKey("CustId")]
        public UserDetail UserDetail { get; set; }

        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }


        public int? PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        public int? CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}

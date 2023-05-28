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
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date_Time { get; set; } = DateTime.Now;
        public float TotalCost { get; set; }
        public string Status { get; set; }
        public DateTime IsScheduledLater { get; set; } = DateTime.Now;
        public string Instructions { get; set; }
        public string PaymentStatus { get; set; }


        public int? CustId { get; set; }
        [JsonIgnore]
        [ForeignKey("CustId")]
        public UserDetail UserDetail { get; set; }

        public int? AddressId { get; set; }
        [JsonIgnore]
        [ForeignKey("AddressId")]
        public Address Address { get; set; }


        public int? PackageId { get; set; }
        [JsonIgnore]
        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        public int? CarId { get; set; }
        [JsonIgnore]
        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}

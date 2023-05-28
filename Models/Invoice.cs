using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public string CustomerName { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public float OrderTotal { get; set; }
        public string PaymentStatus { get; set; }
        public string PackageName { get; set; }
        public string CarName { get; set; }
        public string WasherName { get; set; }
    }
}

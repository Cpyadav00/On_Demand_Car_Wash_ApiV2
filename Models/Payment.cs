using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Payment
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CardHolderName { get; set; }
        public DateTime? Expiry { get; set; }
        public int Cvv { get; set; }
        public string TransactionId { get; set; }
        public int CustomerId { get; set; }
        public double CardNumber { get; set; }
        
    }
}

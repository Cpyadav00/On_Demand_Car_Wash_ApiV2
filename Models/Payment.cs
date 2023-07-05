using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Payment
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Card holder name is required.")]
        [StringLength(50, ErrorMessage = "Card holder name must be between 1 and 50 characters.")]
        public string CardHolderName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Expiry { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [Range(100, 9999, ErrorMessage = "CVV must be a 3 or 4 digit number.")]
        public int Cvv { get; set; }

        public string TransactionId { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Card number must be a 16-digit number.")]
        public double CardNumber { get; set; }
    }

}

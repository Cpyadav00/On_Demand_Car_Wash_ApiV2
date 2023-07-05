using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "WasherId is required.")]
        public int WasherId { get; set; }

        [Required(ErrorMessage = "Ratings of washer is required.")]
        [Range(1, 5, ErrorMessage = "Ratings must be between 1 and 5.")]
        public int RatingsOfWasher { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        public int OrderId { get; set; }
    }

}

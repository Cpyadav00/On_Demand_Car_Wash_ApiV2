using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
   public class Car
{
    [Key]
   
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name must be between 1 and 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Model is required.")]
    [StringLength(50, ErrorMessage = "Model must be between 1 and 50 characters.")]
    public string Model { get; set; }

        [Required(ErrorMessage = "Car number is required.")]
        [StringLength(11, ErrorMessage = "Car number must be between 1 and 11 characters.")]
        public string CarNumber { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [StringLength(20, ErrorMessage = "Status must be between 1 and 20 characters.")]
    public string Status { get; set; }
}

}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Package
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
    }
}

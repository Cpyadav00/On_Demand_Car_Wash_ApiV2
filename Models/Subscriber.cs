using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;

namespace On_Demand_Car_Wash_ApiV2.Models
{
    public class Subscriber
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsSubscribed { get; set; } = true;

    }
}

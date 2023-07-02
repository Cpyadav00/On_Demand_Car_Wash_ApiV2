using System.ComponentModel.DataAnnotations;

namespace On_Demand_Car_Wash_ApiV2.DTOs
{
    public class EmailDTO
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

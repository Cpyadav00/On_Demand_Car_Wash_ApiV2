using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Context
{
    public class CarDbContext:DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) 
        { }
       public DbSet<UserDetail> UserDetails { get; set; }

    }
}

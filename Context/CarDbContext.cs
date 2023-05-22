using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Context
{
    public class CarDbContext:DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) 
        { }
       public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}

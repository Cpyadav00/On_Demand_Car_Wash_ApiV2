using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class OrderSendingDataRepository : IOrderSendingData
    {
        private readonly CarDbContext _dbContext;

        public OrderSendingDataRepository(CarDbContext carDbContext)
        {
            _dbContext = carDbContext;      
        }


        public async Task<List<OrderSendingData>> GetAllDetails()
        {
            var query = (from a in _dbContext.Orders
                         join b in _dbContext.UserDetails
                             on a.CustId equals b.UserId 
                         join d in _dbContext.Cars
                            on a.CarId equals d.Id
                         join e in _dbContext.Packages
                            on a.PackageId equals e.Id
                         join f in _dbContext.Addresses
                         on a.AddressId equals f.Id

                         select new OrderSendingData()
                         {
                             Id = a.Id,
                             CustomerName = b.FirstName + b.LastName,
                             CarName = d.Name,
                             CarModel = d.Model,
                             Adress = f.CustAddress,
                             PackageName = e.Name,
                             DeliveryStatus = a.Status,
                             PaymentStatus = a.PaymentStatus,
                             TotalCost = a.TotalCost,
                             Date_Time = a.Date_Time,
                             WasherName = (b.FirstName+b.LastName)
                         });
            List<OrderSendingData> list1 = await query.ToListAsync();
            return list1;

        }
    }
}

using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class InvoiceRepository:IInvoice
    {
        private readonly CarDbContext _context;
        public InvoiceRepository(CarDbContext context)
        {
            _context = context;
        }

       

        public async Task<List<Invoice>> ViewInvoiceAsync(int id)
        {
            try
            {
                var query = (from a in _context.Orders
                             join b in _context.UserDetails
                             on a.CustId equals b.UserId
                             join d in _context.Cars
                                on a.CarId equals d.Id
                             join e in _context.Packages
                                on a.PackageId equals e.Id

                             select new Invoice()
                             {
                                 CustomerName = b.FirstName+b.LastName,
                                 DateTime = a.DateTime,
                                 PaymentStatus = a.PaymentStatus,
                                 OrderTotal = a.TotalCost,
                                 CarName = d.Name,
                                 PackageName = e.Name
                             });
                List<Invoice> list1 = query.ToList();
               await _context.AddRangeAsync(list1);
               await _context.SaveChangesAsync();
                return list1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

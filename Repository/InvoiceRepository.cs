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

       
        public async Task<List<Invoice>> ViewAllInvoices()
        {
            try
            {
                return await _context.Invoices.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Invoice> ViewInvoiceById(int id)
        {
            try
            {

                return await _context.Invoices.SingleOrDefaultAsync(x => x.InvoiceId == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

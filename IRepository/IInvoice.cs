using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.IRepository
{
    public interface IInvoice
    {
        Task<Invoice> ViewInvoiceById(int id);
        Task<List<Invoice>> ViewAllInvoices();
    }
}

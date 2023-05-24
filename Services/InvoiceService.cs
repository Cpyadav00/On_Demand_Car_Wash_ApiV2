using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Services
{
    public class InvoiceService
    {
        private IInvoice _repository;
        public InvoiceService(IInvoice repository)
        {
            _repository = repository;
        }
        public async Task<List<Invoice>> ViewInvoice(int id)
        {
            return await _repository.ViewInvoiceAsync(id);
        }

    }
}

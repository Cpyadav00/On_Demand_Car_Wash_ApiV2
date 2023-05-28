using Microsoft.AspNetCore.Mvc;
using On_Demand_Car_Wash_ApiV2.Models;
using On_Demand_Car_Wash_ApiV2.Services;

namespace On_Demand_Car_Wash_ApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewInvoiceController : ControllerBase
    {
        public readonly InvoiceService _Service;

        public ViewInvoiceController(InvoiceService service)
        {
            _Service = service;
        }

        [HttpGet]
        [Route("ViewInvoiceById/{id}")]
        public async Task<ActionResult<Invoice>> ViewInvoiceById(int id)
        {
            return await _Service.ViewInvoiceById(id);
        }


        [HttpGet]
        [Route("ViewAllInvoices")]
        public async Task<ActionResult<List<Invoice>>> ViewAllInvoices()
        {
            return await _Service.ViewAllInvoices();
        }

    }
}

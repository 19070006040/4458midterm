using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPA.Context;
using MPA.Contract.Request;
using MPA.Contract.Response;
using MPA.Entity;

namespace MPA.Controllers
{
    public class InvoiceController:ControllerBase
    {
        private readonly MPAContext context;
        public InvoiceController(MPAContext context)
        {
            this.context=context;
        }

        [HttpGet]
        [Route("GetAllInvoices")]
        
        public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.Include(i => i.InvoiceDetails).ToList();
        }
        [HttpPost]
        [Route("AddInvoice")]
        
        public Invoice AddInvoice([FromBody] Invoice invoice)
        {
            foreach (var detail in invoice.InvoiceDetails)
            {
                context.InvoiceDetails.Add(detail);
            }

            context.Invoices.Add(invoice);
            context.SaveChanges();
            return invoice;
        }

        [HttpPost]
        [Route("InvoiceInquiry")]
        public InvoiceInfoResponse InvoiceInquiry([FromBody]InvoiceRequest request)
        {
            var invoice = context.Invoices.Include(i => i.InvoiceDetails).FirstOrDefault(x => x.SubscriberNumber == request.SubscriberNumber && x.Month == request.Month);

            if (invoice != null)
            {
                {
                    return new InvoiceInfoResponse
                    {
                        TotalAmount = invoice.TotalAmount,
                        PaidAmount = invoice.PaidAmount,
                        InvoiceDetails = invoice.InvoiceDetails,
                        Status = invoice.Status,
                    };
                }
            }  return null;
        }

        [HttpPost]
        [Route("DetailedInvoiceInquiry")]
        public IActionResult DetailedInvoiceInquiry([FromBody] InvoiceRequest request)
        {
            var invoice = context.Invoices
            .Include(i => i.InvoiceDetails)
            .FirstOrDefault(x => x.SubscriberNumber == request.SubscriberNumber && x.Month == request.Month);

            if (invoice != null)
            {
                return Ok(new InvoiceDetailResponse
                {
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDetails = invoice.InvoiceDetails,
                });
            }
            else
            {
                return BadRequest("Fatura detayları bulunamadı");
            }

        }
    }
}

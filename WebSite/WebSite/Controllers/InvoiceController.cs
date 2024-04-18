using Microsoft.AspNetCore.Mvc;
using WebSite.Context;
using WebSite.Contract.Request;
using WebSite.Contract.Response;
using WebSite.Entities;

namespace WebSite.Controllers
{
    public class InvoiceController:ControllerBase
    {
        private readonly WebSiteAPIContext context;
        public InvoiceController(WebSiteAPIContext context)
        {
            this.context=context;
        }

        [HttpGet]
        [Route("GetAllInvoices")]
       
        public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }

        [HttpPost]
        [Route("AddInvoice")]
        public InvoiceResponse AddInvoice(AdminRequest adminRequest ,[FromBody]Invoice invoice)
        {
            var loginissuccessfull = context.Admins.Any(x => x.Username == adminRequest.Username && x.Password == adminRequest.Password);
            if (loginissuccessfull)
            {
                context.Add(invoice);
                context.SaveChanges();
                return new InvoiceResponse
                {
                   Response = "Fatura ekleme işlemi başarılı"
                };
            }
            else
            {
                return new InvoiceResponse
                {
                    Response = "Fatura ekleme işlemi başarısız"
                };
            }
        }

        [HttpPost]
        [Route("InvoicePayment")]
        public InvoiceResponse InvoicePayment([FromBody] InvoiceRequest request)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.SubscriberNumber == request.SubscriberNumber && x.Month == request.Month && x.TotalAmount == request.Amount);
            if (invoice.Status == false)
            {
                invoice.Status = true;
                invoice.PaidAmount = request.Amount;
                Invoice invoice1 = new Invoice
                {
                    Id = invoice.Id,
                    Month = invoice.Month,
                    SubscriberNumber = invoice.SubscriberNumber,
                    TotalAmount = invoice.TotalAmount,
                    PaidAmount = invoice.PaidAmount,
                    Status = invoice.Status
                    
                };
                context.SaveChanges();
                return new InvoiceResponse
                {
                    Response = "Ödeme başarılı"
                };
            }
            else
            {
                return new InvoiceResponse
                {
                    Response = "Bu fatura zaten ödenmiş"
                };
            }
        }
    }
}

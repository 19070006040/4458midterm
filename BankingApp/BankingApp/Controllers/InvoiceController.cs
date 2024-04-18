using BankingApp.Context;
using BankingApp.Contract.Request;
using BankingApp.Contract.Response;
using BankingApp.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BankingApp.Controllers
{
    public class InvoiceController:ControllerBase
    {
        private readonly BankingAppContext context;
        public InvoiceController(BankingAppContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetAllInvoices")]
       public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }
        [HttpPost]
        [Route("AddInvoice")]
        
        public Invoice AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return invoice;
        }

        [HttpPost]
        [Route("InvoiceInquiry")]
        public InvoiceInfoResponse InvoiceInquiry(InvoiceRequest request)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.SubscriberNumber == request.SubscriberNumber && x.Month == request.Month);

                if (invoice != null){
                {
                    return new InvoiceInfoResponse
                    {
                        TotalAmount = invoice.TotalAmount,
                        PaidAmount = invoice.PaidAmount,
                        Status = invoice.Status,
                    };
                }
            }
            return null;
        }
    }
}

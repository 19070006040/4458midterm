using MPA.Entity;

namespace MPA.Contract.Response
{
    public class InvoiceInfoResponse
    {
        public decimal TotalAmount {get; set;}
        public decimal PaidAmount {get; set;}
        public ICollection<InvoiceDetail> InvoiceDetails {get; set;}
        public string Status {get; set;}
    }
}

using MPA.Entity;

namespace MPA.Contract.Response
{
    public class InvoiceDetailResponse
    {
        public decimal TotalAmount {get; set;}
        public ICollection<InvoiceDetail> InvoiceDetails {get; set;}
    }
}

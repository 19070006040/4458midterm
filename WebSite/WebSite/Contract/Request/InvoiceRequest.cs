namespace WebSite.Contract.Request
{
    public class InvoiceRequest
    {
        public int SubscriberNumber {get; set;}
        public decimal Amount {get; set;}
        public DateTime Month {get; set;}
    }
}

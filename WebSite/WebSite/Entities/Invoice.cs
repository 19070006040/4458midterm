namespace WebSite.Entities
{
    public class Invoice
    {
        public int Id {get; set;}
        public int SubscriberNumber {get; set;}
        public DateTime Month {get; set;}
        public decimal TotalAmount {get; set;}
        public decimal PaidAmount {get; set;}
        public bool Status {get; set;}
    }
}

namespace BankingApp.Contract.Response
{
    public class InvoiceInfoResponse
    {
        public int Id {get; set;}
        public int SubscriberNumber {get; set;}
        public DateTime Month {get; set;}
        public decimal TotalAmount {get; set;}
        public decimal PaidAmount {get; set;}
        public string Status {get; set;}
    }
}

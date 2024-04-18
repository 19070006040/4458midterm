namespace MPA.Entity
{
    public class InvoiceDetail
    {
        public int Id {get; set;}
        public int InvoiceId {get; set;}
        public string ProductName {get; set;}
        public decimal ProductPrice {get; set;}
        public int Quantity {get; set;}
        public decimal TotalPrice {get; set;}
    }
}

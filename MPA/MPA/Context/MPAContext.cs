using Microsoft.EntityFrameworkCore;
using MPA.Entity;

namespace MPA.Context
{
    public class MPAContext : DbContext
    {
        public MPAContext(DbContextOptions<MPAContext> options): base(options)
        {
            
        }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<InvoiceDetail> InvoiceDetails {get; set;}
    }
}

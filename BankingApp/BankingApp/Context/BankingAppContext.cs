using BankingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Context
{
    public class BankingAppContext : DbContext
    {
        public BankingAppContext(DbContextOptions<BankingAppContext> options):base(options)
        {
            
        }
        public DbSet<Invoice> Invoices {get; set;}
    }
}

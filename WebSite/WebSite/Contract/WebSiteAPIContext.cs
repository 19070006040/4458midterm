using Microsoft.EntityFrameworkCore;
using WebSite.Entities;

namespace WebSite.Context
{
    public class WebSiteAPIContext : DbContext
    {
        public WebSiteAPIContext(DbContextOptions<WebSiteAPIContext> option):base(option)
        {
            
        }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<Admin> Admins {get; set;}
    }
}

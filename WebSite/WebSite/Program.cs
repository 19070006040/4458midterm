using Microsoft.EntityFrameworkCore;
using WebSite.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebSiteAPIDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddDbContext<WebSiteAPIContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

using Microsoft.EntityFrameworkCore;

using TestContainers.Demo;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<AppDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/customers", async (AppDbContext dbContext) =>
{
    return await dbContext.Customers.ToListAsync();
});

app.MapPost("/customers", async (Customer customer, AppDbContext dbContext) =>
{
    await dbContext.Customers.AddAsync(customer);
    await dbContext.SaveChangesAsync();

    return customer;
});

app.Run();

public partial class Program { }
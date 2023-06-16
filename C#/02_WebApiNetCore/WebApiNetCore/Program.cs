using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiNetCore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApiNetCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiNetCoreContext") ?? throw new InvalidOperationException("Connection string 'WebApiNetCoreContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

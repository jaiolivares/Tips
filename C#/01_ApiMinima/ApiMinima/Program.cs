using ApiMinima.Data;
using ApiMinima.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConStrSqlConnection");

builder.Services.AddDbContext<OfficeDb>(options =>
    options.UseSqlServer(connectionString)
);

//Para utilizar BD de PostgreSQL
//Instalar paquete => Npgsql.EntityFrameworkCore.PostgreSQL
//Para SQL instalar paquete => Microsoft.EntityFrameworkCore.SqlServer
/*
builder.Services.AddDbContext<OfficeDb>(options =>
    options.UseNpgsql(connectionString)
);
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//Insert
app.MapPost("/employees/", async (Employee e, OfficeDb db) =>
{
    db.Employees.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/employee/{e.Id}", e);
});

//Select Where
app.MapGet("/employees/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Employees.FindAsync(id)
    is Employee e
    ? Results.Ok(e)
    : Results.NotFound();
});

//Select All
app.MapGet("/employees", async (OfficeDb db) => await db.Employees.ToListAsync());

//Update
app.MapPut("/employees/{id:int}", async (int id, Employee e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var employee = await db.Employees.FindAsync(id);

    if (employee is null)
        return Results.NotFound();

    employee.FirstName = e.FirstName;
    employee.LastName = e.LastName;
    employee.Branch = e.Branch;
    employee.Age = e.Age;

    await db.SaveChangesAsync();

    return Results.Ok(employee);
});

//Delete
app.MapDelete("/employees/{id:int}", async(int id, OfficeDb  db) =>
{
    var employee = await db.Employees.FindAsync(id);

    if (employee is null)
        return Results.NotFound();

    db.Employees.Remove(employee);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
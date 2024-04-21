using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Windows.Services.Store;

string connectionDb = "Data Source=JOLIVARESPC;Initial Catalog=StorageExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
optionsBuilder.UseSqlServer(connectionDb);

using (var db = new StoreContext(optionsBuilder.Options))
{
    var result = db.Database.SqlQueryRaw<string>("" +
        "SELECT Brands.Name as Name," +
        "(SELECT Beers.Name" +
        "FROM Beers" +
        "WHERE Beers.BrandID = Brands.BrandID" +
        "FOR JSON PATH)" +
        "AS Beers" +
        "FROM Brands" +
        "FOR JSON PATH" +
        "").ToList();

    var brandBeers = JsonSerializer.Deserialize<List<Brand>>(result[0]);

    foreach (var brand in brandBeers)
    {
        Console.WriteLine(brand.Name);

        foreach (var beer in brand.Beers)
        {
            Console.WriteLine("--" + beer.Name);
        }
    }
}

internal class Brand
{
    public string Name { get; set; }
    public List<Beer> Beers { get; set; }
}

internal class Beer
{
    public string Name { get; set; }
}
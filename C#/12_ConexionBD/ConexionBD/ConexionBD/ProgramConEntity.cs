using Microsoft.EntityFrameworkCore;

namespace ConexionBD
{
    public class ProgramConEntity : DbContext
    {
        public DbSet<Beer> Beers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=JOLIVARESPC;Initial Catalog=StorageExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connection);
        }

        public static void ConsultarBd()
        {
            using (var db = new ProgramConEntity())
            {
                var result = db.Beers.FromSqlRaw("SELECT BeerID, Name, BrandID, Alcohol FROM Beers").ToList();

                foreach (Beer brand in result)
                {
                    Console.WriteLine(brand.BeerID + " " + brand.Name);
                }
            }
        }
    }

    public class Beer
    {
        public int BeerID { get; set; }
        public string Name { get; set; }

        public int BrandID { get; set; }
        public decimal Alcohol { get; set; }
    }
}
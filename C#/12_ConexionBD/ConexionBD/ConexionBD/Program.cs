using ConexionBD;
using Microsoft.Data.SqlClient;

string connectionDb = "Data Source=JOLIVARESPC;Initial Catalog=StorageExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
string query = "SELECT BeerID, Name, BrandID, Alcohol FROM Beers";

using (SqlConnection connection = new SqlConnection(connectionDb))
{
    SqlCommand command = new SqlCommand(query, connection);

    connection.Open();

    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["BeerID"]}, Nombre: {reader["Name"]}, BrandID: {reader["BrandID"]}");
    }
    reader.Close();

    ProgramConEntity.ConsultarBd();
}
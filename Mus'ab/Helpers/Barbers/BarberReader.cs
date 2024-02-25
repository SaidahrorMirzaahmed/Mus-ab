using Mus_ab.Models;
using Mus_ab.Models.barbers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Helpers.Barbers;

public class BarberReader
{
    public List<Barber> ReadBarbers()
    {
        List<Barber> barbers = new List<Barber>();
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";


        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, first_name, last_name, email, password, rating FROM barbers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Barber barber = new Barber
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Password = reader.GetString(reader.GetOrdinal("password")),
                                Rating = reader.GetDecimal(reader.GetOrdinal("rating"))
                            };

                            barbers.Add(barber);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return barbers;
    }
}

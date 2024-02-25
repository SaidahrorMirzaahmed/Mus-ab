using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Ratings;

public class RatingReader
{
    public List<Rating> ReadRatings()
    {
        List<Rating> ratings = new List<Rating>();
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id, barber_id, barber_id, rating FROM ratings";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rating rating = new Rating
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                BarberId = reader.GetInt32(reader.GetOrdinal("barber_id")),
                                Ratingg = reader.GetDecimal(reader.GetOrdinal("rating"))
                            };

                            ratings.Add(rating);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return ratings;
    }

}

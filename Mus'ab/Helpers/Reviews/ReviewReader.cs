using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Reviews;

public class ReviewReader
{
    public List<Review> ReadReviews()
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        List<Review> reviews = new List<Review>();

        try
        {
            // Query to retrieve reviews
            string query = "SELECT id, barber_id, customer_id, message FROM reviews";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the SQL query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlDataReader object to read the query results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any rows returned by the query
                        while (reader.Read())
                        {
                            // Create a new Review object and populate its properties
                            Review review = new Review
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                BarberId = reader.GetInt32(reader.GetOrdinal("barber_id")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                Message = reader.GetString(reader.GetOrdinal("message"))
                            };

                            // Add the review to the list
                            reviews.Add(review);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return reviews;
    }

}

using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Ratings;

public class RatingWriter
{
    public bool WriteRatings(List<Rating> ratings)
    {
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        try
        {
            // Delete existing ratings before writing new ones
            DeleteAllRatings();

            // Insert new ratings
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var rating in ratings)
                {
                    string query = @"INSERT INTO ratings (user_id, barber_id, rating) 
                                 VALUES (@UserId, @BarberId, @Rating)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", rating.UserId);
                        command.Parameters.AddWithValue("@BarberId", rating.BarberId);
                        command.Parameters.AddWithValue("@Rating", rating.Ratingg);

                        command.ExecuteNonQuery();
                    }
                }
            }

            return true; // Successfully inserted all ratings
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false; // Failed to insert one or more ratings
        }
    }

    private void DeleteAllRatings()
    {
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ratings";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting ratings: " + ex.Message);
        }
    }

}

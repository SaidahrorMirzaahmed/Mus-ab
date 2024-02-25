using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Reviews;

public class ReviewWriter
{
    public bool Main(List<Review> reviews)
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";
        try
        {
            // Delete existing data from the Reviews table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL DELETE statement to remove all records from the Reviews table
                string deleteQuery = "DELETE FROM reviews";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    // Execute the delete command
                    deleteCommand.ExecuteNonQuery();
                }
            }

            // Insert new data into the Reviews table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var review in reviews)
                {
                    // SQL INSERT statement to insert each review into the Reviews table
                    string insertQuery = @"INSERT INTO reviews (barber_id, customer_id, message) 
                                       VALUES (@BarberId, @CustomerId, @Message)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Adjust parameters for the Reviews table
                        insertCommand.Parameters.AddWithValue("@BarberId", review.BarberId);
                        insertCommand.Parameters.AddWithValue("@CustomerId", review.CustomerId);
                        insertCommand.Parameters.AddWithValue("@Message", review.Message);

                        // Execute the insert command
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false; // Return false if an error occurs
        }
        return true; // Return true if the operation is successful
    }

}
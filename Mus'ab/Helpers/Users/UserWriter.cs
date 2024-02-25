using Mus_ab.Models.users;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Users;

public class UserWriter
{
    public bool Main(List<User> users)
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";
        try
        {
            // Delete existing data from the Users table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL DELETE statement to remove all records from the Users table
                string deleteQuery = "DELETE FROM users";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    // Execute the delete command
                    deleteCommand.ExecuteNonQuery();
                }
            }

            // Insert new data into the Users table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var user in users)
                {
                    // SQL INSERT statement to insert each user into the Users table
                    string insertQuery = @"INSERT INTO users (first_name, last_name, email, password, phone) 
                                       VALUES (@FirstName, @LastName, @Email, @Password, @Phone)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Adjust parameters for the Users table
                        insertCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                        insertCommand.Parameters.AddWithValue("@LastName", user.LastName);
                        insertCommand.Parameters.AddWithValue("@Email", user.Email);
                        insertCommand.Parameters.AddWithValue("@Password", user.Password);
                        insertCommand.Parameters.AddWithValue("@Phone", user.Phone);

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

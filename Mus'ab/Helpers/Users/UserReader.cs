using Mus_ab.Models.users;
using System.Data.SqlClient;
namespace Mus_ab.Helpers.Users;

public class UserReader
{
    public List<User> Main()
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";
        // SQL query to retrieve data from the User table
        string query = "SELECT id, first_name, last_name, email, password, phone  FROM users";

        // List to store User objects
        List<User> users = new List<User>();

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
                        // Create a new User object and populate its properties
                        User user = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            Phone = reader.GetString(reader.GetOrdinal("phone"))
                        };

                        // Add the message to the list
                        users.Add(user);
                    }
                }
            }
        }

        // Output the retrieved messages
        return users;
    }
}


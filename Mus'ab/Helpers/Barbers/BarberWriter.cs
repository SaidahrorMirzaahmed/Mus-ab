using Mus_ab.Models.barbers;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Barbers;

public class BarberWriter
{
    public bool WriteBarbers(List<Barber> barbers)
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        try
        {
            // Delete existing barber records
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL DELETE statement to remove all records from the Barbers table
                string deleteQuery = "DELETE FROM Barbers";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    // Execute the delete command
                    deleteCommand.ExecuteNonQuery();
                }
            }

            // Insert new barber records
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var barber in barbers)
                {
                    // SQL INSERT statement to insert each barber into the Barbers table
                    string insertQuery = @"INSERT INTO Barbers (first_name, last_name, email, password, rating) 
                                       VALUES (@FirstName, @LastName, @Email, @Password, @Rating)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Adjust parameters for the Barbers table
                        insertCommand.Parameters.AddWithValue("@FirstName", barber.FirstName);
                        insertCommand.Parameters.AddWithValue("@LastName", barber.LastName);
                        insertCommand.Parameters.AddWithValue("@Email", barber.Email);
                        insertCommand.Parameters.AddWithValue("@Password", barber.Password);
                        insertCommand.Parameters.AddWithValue("@Rating", barber.Rating);

                        // Execute the insert command
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }

            return true; // Successfully inserted all barbers
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false; // Failed to insert one or more barbers
        }
    }



}

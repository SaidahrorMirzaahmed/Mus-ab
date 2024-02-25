using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Appointments;

public class AppointmentWriter
{
    public bool WriteOrders(List<Appointment> orders)
    {
        // Connection string to connect to your SQL Server database
        string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Begin a transaction
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var order in orders)
                        {
                            // SQL INSERT query to insert each order into the Orders table
                            string query = @"INSERT INTO orders (barber_id, user_id, order_time, additionalPrice, additional_features) 
                             VALUES (@barber_id, @UserId, @order_time, @AdditionalPrice, @AdditionalFeatures)";

                            // Create a SqlCommand object with the query and connection
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                // Set parameter values
                                command.Parameters.AddWithValue("@barber_id", order.BarberId);
                                command.Parameters.AddWithValue("@UserId", order.UserId);
                                command.Parameters.AddWithValue("@order_time", order.OrderTime); // Corrected parameter name
                                command.Parameters.AddWithValue("@AdditionalPrice", order.AdditionalPrice);
                                command.Parameters.AddWithValue("@AdditionalFeatures", order.AdditionalFeatures);

                                // Execute the query
                                command.ExecuteNonQuery();
                            }
                        }

                        // Commit the transaction if all orders are inserted successfully
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        // Rollback the transaction if an error occurs
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Helpers;

public class AvailabilityChecker
{
    string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

    public bool BookOrder(string orderTime, int barberId)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Begin a database transaction
            using (var transaction = connection.BeginTransaction())
            {
                // Check if the order time is available
                if (!IsOrderTimeAvailable(connection, transaction, orderTime, barberId))
                {
                    return false;
                }

            }
        }
        return true;
    }
    private bool IsOrderTimeAvailable(SqlConnection connection, SqlTransaction transaction, string orderTime, int barberId)
    {
        // Check if there is any existing order for the given time and barber
        string query = "SELECT COUNT(*) FROM orders WHERE order_time = @order_time AND barber_id = @barber_id";
        using (var command = new SqlCommand(query, connection, transaction))
        {
            command.Parameters.AddWithValue("@order_time", orderTime);
            command.Parameters.AddWithValue("@barber_id", barberId);
            int existingOrders = (int)command.ExecuteScalar();
            return existingOrders == 0; // Time slot is available if no existing orders for the barber
        }
    }
}

using Mus_ab.Models;
using System.Data.SqlClient;

namespace Mus_ab.Helpers.Appointments;

public class AppointmentReader
{

    string connectionString = "Server=34.70.244.16,1433;Database=project;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

    public List<Appointment> ReadAppointments()
    {
        List<Appointment> orders = new List<Appointment>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, barber_id, user_id, order_time, additionalPrice, additional_features FROM orders";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment order = new Appointment
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                BarberId = reader.GetInt32(reader.GetOrdinal("barber_id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                OrderTime = reader.GetString(reader.GetOrdinal("order_time")),
                                AdditionalPrice = reader.GetDecimal(reader.GetOrdinal("additionalPrice")),
                                AdditionalFeatures= reader.GetString(reader.GetOrdinal("additional_features"))

                            };

                            orders.Add(order);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return orders;
    }
}




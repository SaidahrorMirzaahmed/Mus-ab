using Mus_ab.Models;
using Mus_ab.Services;
using Spectre.Console;

namespace Mus_ab.UIs.BarberUis;

public class CheckForBookingsUI
{
    AppointmentService AppointmentService = new AppointmentService();
    UserService UserService = new UserService();
    public async Task Menu(int barberId)
    {
        var appointments = await AppointmentService.GetAllAsync();
        var list = appointments.Where(x => x.BarberId == barberId).ToList();
        await Displayer(list);
    }
    async Task Displayer(List<Appointment> appointments)
    {
        var table = new Table();

        // Add columns to the table
        table.AddColumn("ID");
        table.AddColumn("First Name");
        table.AddColumn("Client Contact");
        table.AddColumn("Order Time");
        table.AddColumn("Additional Price");
        table.AddColumn("Additional Features");

        // Add rows to the table
        foreach (Appointment appointment in appointments)
        {
            var user = await UserService.GetByIdAsync(appointment.UserId);
            table.AddRow(
                appointment.Id.ToString(),
                user.FirstName.ToString(),
                user.Phone.ToString(),
                appointment.OrderTime,
                appointment.AdditionalPrice.ToString(),
                appointment.AdditionalFeatures
            );
        }
        AnsiConsole.Write(table);
    }
}

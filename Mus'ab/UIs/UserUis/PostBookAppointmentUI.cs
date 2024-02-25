using Mus_ab.Helpers;
using Mus_ab.Models;
using Mus_ab.Services;
using Spectre.Console;

namespace Mus_ab.UIs.UserUis;

public class PostBookAppointmentUI
{
    AppointmentService AppointmentService = new AppointmentService();
    AvailabilityChecker AvailabilityChecker = new AvailabilityChecker();
    public async Task Menu(int userId, int barberId)
    {
        Appointment appointment = new Appointment();
        appointment.UserId = userId;
        appointment.BarberId = barberId;
        var choice = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
         .Title("Select an hour")
         .PageSize(10)
         .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
         .AddChoices(new[] {
           "9:00", "10:00", "11:00", "12:00",
            "13:00", "14:00", "15:00", "16:00", "17:00"
         }));
        if (AvailabilityChecker.BookOrder(choice, barberId))
        {
            appointment.OrderTime = choice;

            var comforts = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Select Extra Comforts for Your Barber Salon Experience")
                .NotRequired() // Not required to select any comfort
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more comforts)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a comfort, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(new[] {
                    "Refreshing Towels", "Hot Towel Treatment", "Shampoo & Conditioner",
                    "Massage Chair", "Aromatherapy", "Foot Massage",
                    "Hair Styling Products", "Facial Treatment", "Refreshments",
                }));

            appointment.AdditionalPrice = comforts.Count() * 5000;
            string selectedComforts = string.Join(", ", comforts);
            appointment.AdditionalFeatures = selectedComforts;
            var res = await AppointmentService.CreateAsync(appointment);
            Display(res);
        }
        else
        {
            AnsiConsole.Markup("[red]Sorry, the selected time slot is not available[/]\n");
        }


    }
    void Display(Appointment appointment)
    {
        var table = new Table();

        // Add columns to the table
        table.AddColumn("ID");
        table.AddColumn("Barber ID");
        table.AddColumn("User ID");
        table.AddColumn("Order Time");
        table.AddColumn("Additional Price");
        table.AddColumn("Additional Features");

        // Add rows to the table

        table.AddRow(
            appointment.Id.ToString(),
            appointment.BarberId.ToString(),
            appointment.UserId.ToString(),
            appointment.OrderTime,
            appointment.AdditionalPrice.ToString(),
            appointment.AdditionalFeatures
        );


        // Render the table
        AnsiConsole.Write(table);

    }
}




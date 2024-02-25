using Mus_ab.Models;
using Spectre.Console;

namespace Mus_ab.UIs.UserUis;

public class BookAppointment
{
    PostBookAppointmentUI PostBookAppointmentUI = new PostBookAppointmentUI();
    public async Task Menu(int userId)
    {
        Appointment appointment = new Appointment();
        var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more channels)[/]")
        .AddChoices(new[] {
        "Zafar", "Abror", "Kamila", "Alisher", "Robiya"
        }));
        switch (choice)
        {
            case "Zafar": await PostBookAppointmentUI.Menu(userId, 1); break;
            case "Abror": await PostBookAppointmentUI.Menu(userId, 2); break;
            case "Kamila": await PostBookAppointmentUI.Menu(userId, 3); break;
            case "Alisher": await PostBookAppointmentUI.Menu(userId, 4); break;
            case "Robiya": await PostBookAppointmentUI.Menu(userId, 5); break;
        }
    }
}

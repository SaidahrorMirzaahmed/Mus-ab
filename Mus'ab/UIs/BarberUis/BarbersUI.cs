using Mus_ab.Models.barbers;
using Mus_ab.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.BarberUis;

public class BarbersUI
{
    BarberService barberService = new BarberService();
    public async Task Menu()
    {
        var list = await barberService.OrderByRatingAsync();
        DisplayBarbers(list);
    }
    private void DisplayBarbers(List<BarberView> barbers)
    {
        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn(new TableColumn("Firstname").Centered());
        table.AddColumn(new TableColumn("LastName").Centered());
        table.AddColumn(new TableColumn("Rating").Centered());
        table.AddColumn(new TableColumn("email").Centered());

        foreach (var barber in barbers)
        {
            table.AddRow($"{barber.Id}", $"[green]{barber.FirstName}[/]", $"[green]{barber.LastName}[/]", $"[darkseagreen1]{barber.Rating}[/]", $"[royalblue1]{barber.Email}[/]");
        }

        // Render the table to the console
        AnsiConsole.Write(table);
    }
}

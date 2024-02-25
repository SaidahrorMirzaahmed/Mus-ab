using Mus_ab.Helpers.Barbers;
using Mus_ab.Models.barbers;
using Mus_ab.Models.users;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.BarberUis;

public class BarberProfile
{
    BarberReader BarberReader= new BarberReader();
    public void Menu(int barberId)
    {
        var list=BarberReader.ReadBarbers();
        var exist=list.ToList().FirstOrDefault(b=>b.Id==barberId);
        Display(exist);
    }
    void Display(Barber user)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("First Name");
        table.AddColumn("Last Name");
        table.AddColumn("Email");
        table.AddColumn("Password");
        table.AddColumn("Rating");

        // Add rows to the table

        table.AddRow($"{user.Id}", $"[blue]{user.FirstName}[/]", $"[blue]{user.LastName}[/]", $"[yellow]{user.Email}[/]", $"[green]{user.Password} [/]", user.Rating.ToString());
        AnsiConsole.Write(table);
    }
}

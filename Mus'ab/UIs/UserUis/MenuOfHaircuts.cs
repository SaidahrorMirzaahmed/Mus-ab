using Mus_ab.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.UserUis;

public class MenuOfHaircuts
{
    public void Menu()
    {
        var haircuts = new List<Haircut>();
        Haircut haircut1 = new Haircut { Name = "Trim", Price = "2000" };
        haircuts.Add(haircut1);
        Haircut haircut2 = new Haircut { Name = "Buzz Cut", Price = "1500" };
        haircuts.Add(haircut2);
        Haircut haircut3 = new Haircut { Name = "Layered Cut", Price = "2500" };
        haircuts.Add(haircut3);
        Haircut haircut4 = new Haircut { Name = "Crew Cut", Price = "1800" };
        haircuts.Add(haircut4);
        Haircut haircut5 = new Haircut { Name = "Pixie Cut", Price = "3000" };
        haircuts.Add(haircut5);
        Haircut haircut6 = new Haircut { Name = "Fade", Price = "2200" };
        haircuts.Add(haircut6);
        Haircut haircut7 = new Haircut { Name = "Bob Cut", Price = "2800" };
        haircuts.Add(haircut7);
        Haircut haircut8 = new Haircut { Name = "Pompadour", Price = "3500" };
        haircuts.Add(haircut8);
        Haircut haircut9 = new Haircut { Name = "Shag Cut", Price = "2700" };
        haircuts.Add(haircut9);
        Haircut haircut10 = new Haircut { Name = "Undercut", Price = "3200" };
        haircuts.Add(haircut10);

        Display(haircuts);
    }
    private void Display(List<Haircut> haircuts)
    {
        var table = new Table();

        // Add columns to the table
        table.AddColumn("Name");
        table.AddColumn("Price");

        // Add rows to the table
        foreach (var haircut in haircuts)
        {
            table.AddRow($"[blue]{haircut.Name}[/]", haircut.Price); // Format price as currency
        }
        AnsiConsole.Write(table);
    }

}

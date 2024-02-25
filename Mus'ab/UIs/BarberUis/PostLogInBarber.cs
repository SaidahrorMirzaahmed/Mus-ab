using Mus_ab.Models.users;
using Mus_ab.Services;
using Mus_ab.UIs.UserUis;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.BarberUis;

public class PostLogInBarber
{
    CheckForBookingsUI CheckForBookingsUI = new CheckForBookingsUI();
    BarberProfile BarberProfile = new BarberProfile();
    ReadReviewsUI readReviewsUI = new ReadReviewsUI();
    public async Task Main(int barberId)
    {
        var haveto = true;
        while (haveto)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Do u want to UPDATE your profile")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more channels)[/]")
                .AddChoices(new[] {
            "Check for bookings", "Comments about myself", "Profile", "Exit"
                }));
            switch (choice)
            {
                case "Check for bookings": await CheckForBookingsUI.Menu(barberId); break;
                case "Comments about myself":await readReviewsUI.Menu(barberId);  break;
                case "Profile": BarberProfile.Menu(barberId); break;
                case "Exit": haveto = false; break;
            }
            AnsiConsole.Write(new Markup("[green] You kogged in press {ENTER} to continue[/]\n"));
            Console.ReadLine();
            Console.Clear();
        }
    }
}

using Mus_ab.UIs.BarberUis;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.UserUis;

public class PostLogInUI
{
    BarbersUI BarbersUI = new BarbersUI();
    MenuOfHaircuts MenuOfHaircuts = new MenuOfHaircuts();
    ProfileUI ProfileUI = new ProfileUI();
    BookAppointment BookAppointment = new BookAppointment();
    PreReviewBarberUI PreReviewBarberUI = new PreReviewBarberUI();
    PreReadReviews PreReadReviews = new PreReadReviews();
    public async Task Menu(int userId)
    {
        var haveto = true;
        while (haveto)
        {
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more channels)[/]")
            .AddChoices(new[] {
            "Book an Appointment", "Menu of Haircuts", "Barbers", "Profile", "Comment about barber", "Read reviews about barbers", "Exit"
            }));
            switch (choice)
            {
                case "Book an Appointment":await BookAppointment.Menu(userId); break;
                case "Menu of Haircuts": MenuOfHaircuts.Menu(); break;
                case "Barbers": await BarbersUI.Menu(); break;
                case "Profile": await ProfileUI.Menu(userId); break;
                case "Comment about barber":await PreReviewBarberUI.Menu(userId); break;
                case "Read reviews about barbers":await PreReadReviews.Menu(); break;
                case "Exit": haveto = false; break;

            }
            AnsiConsole.Write(new Markup("[green]press {ENTER} to continue[/]\n"));
            Console.ReadLine();
            Console.Clear();
        }
    }
}

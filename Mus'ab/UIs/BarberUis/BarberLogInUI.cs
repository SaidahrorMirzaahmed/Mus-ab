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

public class BarberLogInUI
{
    private List<Barber> barbers = new List<Barber>();
    BarberReader barberReader = new BarberReader();
    PostLogInBarber PostLogInBarber = new PostLogInBarber();
    public async Task Menu()
    {
        var haveto = true;
        while (haveto)
        {
            barbers = barberReader.ReadBarbers();
            var email = AnsiConsole.Ask<string>("What's your [green]name[/]?");
            var exist = barbers.FirstOrDefault(x => x.FirstName == email);
            if (exist == null)
            {
                AnsiConsole.Write(new Markup("[red] User is not found[/]\n"));
                AnsiConsole.Write(new Markup("[green] You kogged in press {ENTER} to continue[/]\n"));
                Console.ReadLine();
                Console.Clear();
            }
            else
            {

                var password = AnsiConsole.Ask<string>("What's your [green]password[/]?");
                if (exist.Password == password)
                {
                    AnsiConsole.Write(new Markup("[green] You kogged in press {ENTER} to continue[/]\n"));
                    Console.ReadLine();
                    Console.Clear();
                    await PostLogInBarber.Main(exist.Id);
                }
                else
                {
                    AnsiConsole.Write(new Markup("[red] Incorrect password\n[/]"));
                    var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Do u want to exit[/]?")
                        .PageSize(10)
                        .MoreChoicesText("")
                        .AddChoices(new[] {
                        "yes", "no"
                        }));
                    switch (choice)
                    {
                        case "yes": haveto = false; break;
                        case "no": haveto = true; break;
                    }

                }
            }
            AnsiConsole.Write(new Markup("[green] You kogged in press {ENTER} to continue[/]\n"));
            Console.ReadLine();
            Console.Clear();
        }
    }
}

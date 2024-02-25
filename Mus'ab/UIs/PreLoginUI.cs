using Mus_ab.UIs.BarberUis;
using Spectre.Console;

namespace Mus_ab.UIs;

public class PreLoginUI
{
    LogInUI LogInUI = new LogInUI();
    BarberLogInUI BarberLogInUI = new BarberLogInUI();
    public async void Menu()
    {
        var choice = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
           .Title("Ur position")
           .PageSize(10)
           .MoreChoicesText("[grey](Move up and down to reveal more channels)[/]")
           .AddChoices(new[] {
            "User", "Barber"
           }));
        switch (choice)
        {
            case "User": await LogInUI.Menu(); break;
            case "Barber":await BarberLogInUI.Menu(); break;
        }
    }
}

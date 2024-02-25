using Mus_ab.UIs.UserUis;
using Spectre.Console;

namespace Mus_ab.UIs;

public class MainUI
{
    RegisterUI registerUI= new RegisterUI();
    PreLoginUI PreLoginUI = new PreLoginUI();   
    public async Task Menu()
    {
        var haveto = true;
        while (haveto)
        {
            AnsiConsole.Write(
           new FigletText("Welcome to MUS'AB")
           .Centered()
           .Color(Color.Blue));
            var choice = AnsiConsole.Prompt(
          new SelectionPrompt<string>()
            .Title("")
            .PageSize(10)
            .MoreChoicesText("[grey](There is no exit button just press X)[/]")
            .AddChoices(new[] {
            "Register", "Log in", "Exit"
            }));
            switch (choice)
            {
                case "Register": await registerUI.Register(); break;
                case "Log in": PreLoginUI.Menu(); break;
                case "Exit": haveto = false; break;
            }
        }
    }
}

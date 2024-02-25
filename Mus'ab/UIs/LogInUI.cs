using Mus_ab.Services;
using Mus_ab.UIs.UserUis;
using Spectre.Console;

namespace Mus_ab.UIs;

public class LogInUI
{
    UserService UserServices = new UserService();
    PostLogInUI PostLoginUI = new PostLogInUI();
    public async Task Menu()
    {
        var haveto = true;
        while (haveto)
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx =>
            {

                Thread.Sleep(1000);


                ctx.Status("Thinking some more");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));


            });
            var users = await UserServices.GetAllUsersAsync();
            var email = AnsiConsole.Ask<string>("What's your [green]email[/]?");
            var exist = users.FirstOrDefault(x => x.Email == email);
            if (exist == null)
            {
                AnsiConsole.Write(new Markup("[red] User is not found[/]\n"));
            }
            else
            {

                var password = AnsiConsole.Ask<string>("What's your [green]password[/]?");
                if (exist.Password == password)
                {
                    AnsiConsole.Write(new Markup("[green] You kogged in press {ENTER} to continue[/]\n"));
                    Console.ReadLine();
                    Console.Clear();
                    await PostLoginUI.Menu(exist.Id);
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
            AnsiConsole.Write(new Markup("[green] press {ENTER} to continue[/]\n"));
            Console.ReadLine();
            Console.Clear();
        }
    }
}

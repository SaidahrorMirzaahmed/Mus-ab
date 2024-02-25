using Spectre.Console;

namespace Mus_ab.UIs.UserUis;

public class PreReviewBarberUI
{
    CommentBarerUI commentBarerUI= new CommentBarerUI();
    public async Task Menu(int userId)
    {
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
            case "Zafar": await commentBarerUI.Menu(userId, 1); break;
            case "Abror": await commentBarerUI.Menu(userId, 2); break;
            case "Kamila": await commentBarerUI.Menu(userId, 3); break;
            case "Alisher": await commentBarerUI.Menu(userId, 4); break;
            case "Robiya": await commentBarerUI.Menu(userId, 5); break;
        }
    }
}

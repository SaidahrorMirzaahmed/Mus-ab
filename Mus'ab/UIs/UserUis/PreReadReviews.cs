using Mus_ab.Models.users;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.UserUis;

public class PreReadReviews
{
    ReadReviewsUI ReadReviewsUI= new ReadReviewsUI();
    public async Task Menu()
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
            case "Zafar": await ReadReviewsUI.Menu(1); break;
            case "Abror": await ReadReviewsUI.Menu(2); break;
            case "Kamila": await ReadReviewsUI.Menu(3); break;
            case "Alisher": await ReadReviewsUI.Menu(4); break;
            case "Robiya": await ReadReviewsUI.Menu(5); break;
        }
    }
}

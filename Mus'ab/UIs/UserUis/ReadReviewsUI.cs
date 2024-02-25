using Mus_ab.Models;
using Mus_ab.Services;
using Spectre.Console;

namespace Mus_ab.UIs.UserUis;

public class ReadReviewsUI
{
    ReviewService reviewService=new ReviewService();
    UserService UserService = new UserService();
    public async Task Menu(int barberId)
    {
        var list= await reviewService.GetReviewByBarberId(barberId);
        if (list.Count == 0)
        {
            AnsiConsole.Markup("[green]No comments yet[/]");
        }
        else
        {
            await Display(list);
        }

    }
    async Task Display(List<Review> reviews)
    {
        var table = new Table();
        table.AddColumn("Email");
        table.AddColumn(new TableColumn("Message").Centered());
        foreach (Review review in reviews)
        {
            var user =await UserService.GetByIdAsync(review.CustomerId);
            table.AddRow($"{user.Email}", $"{review.Message}");

            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }
}

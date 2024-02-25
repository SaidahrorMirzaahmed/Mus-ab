using Mus_ab.Helpers.Reviews;
using Mus_ab.Models;
using Mus_ab.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.UIs.UserUis;

public class CommentBarerUI
{
    ReviewService ReviewService= new ReviewService();
    public async Task Menu(int userId, int barberId)
    {
        Review review = new Review();
        var message=AnsiConsole.Ask<string>("Leave your comments");
        review.CustomerId = userId;
        review.BarberId = barberId;
        review.Message = message;
        await ReviewService.CreateAsync(review);
        AnsiConsole.Markup("Thank you for the comment");
    }
}

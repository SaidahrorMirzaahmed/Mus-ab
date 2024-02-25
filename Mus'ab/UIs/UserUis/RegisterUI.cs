using Mus_ab.Models.users;
using Mus_ab.Services;
using Spectre.Console;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Mus_ab.UIs.UserUis;

public class RegisterUI
{
    UserService UserServices = new UserService();
    public async Task Register()
    {
        Random random = new Random();
        UserCreation userCreation = new UserCreation();
        userCreation.FirstName = AnsiConsole.Ask<string>("What's your [green]FirstName[/]?");
        userCreation.LastName = AnsiConsole.Ask<string>("What's your [green]LastName[/]?");
        AnsiConsole.Markup("What's your [green]Phone Number[/] +998 ");
        var input = Console.ReadLine();
        while (!ValidatePhoneNumber(input))
        {
            AnsiConsole.Markup("[red]Invalid input[/]?");
            AnsiConsole.Markup("What's your [green]Phone Number[/]?");
            input = Console.ReadLine();
        }
        userCreation.Phone = input;
        userCreation.Password = AnsiConsole.Prompt(
        new TextPrompt<string>("Enter [green]password[/]?")
        .PromptStyle("red")
        .Secret());
        string recipientEmail = "";
        var boool = true;
        while (boool)
        {
            recipientEmail = AnsiConsole.Ask<string>("What's your [green]Email[/]?\nCode will be send to to your e-mail");
            string senderEmail = "saidahror03189@gmail.com";
            string appPassword = "qnovhrqojuxhkadh";

            string subject = "Verification Code";
            int body = random.Next(1000, 9999);

            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body.ToString());

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, appPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                AnsiConsole.Write(new Markup("[bold yellow]E-mail[/] [blue]Sent successfully![/]"));
                var code = AnsiConsole.Ask<int>("What's your [green]Code[/]?");
                if (code == body) userCreation.Email = recipientEmail;
                else
                    throw new Exception("wrong code");

                boool = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
        var final = await UserServices.CreateAsync(userCreation);
        DisplayViewUser(final);
    }
    private void DisplayViewUser(UserView userViewModel)
    {
        var table = new Table();


        table.AddColumn("Id");
        table.AddColumn(new TableColumn("Username").Centered());
        table.AddColumn(new TableColumn("Email").Centered());

        table.AddRow(new Markup($"[blue]{userViewModel.Id}[/]"), new Markup($"[lime]{userViewModel.FirstName}[/]"), new Markup($"[lime]{userViewModel.Email}[/]"));

        AnsiConsole.Write(table);
    }
    public static bool ValidatePhoneNumber(string phoneNumber)
    {
        // Regular expression pattern to match exactly 9 digits
        string pattern = @"^\d{9}$";

        // Create a Regex object with the pattern
        Regex regex = new Regex(pattern);

        // Match the phone number against the pattern
        Match match = regex.Match(phoneNumber);

        // Return true if the phone number matches the pattern, false otherwise
        return match.Success;
    }

}

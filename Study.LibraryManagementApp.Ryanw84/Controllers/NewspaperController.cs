using Spectre.Console;
using Study.LibraryManagementApp.Ryanw84.Models;

namespace Study.LibraryManagementApp.Ryanw84.Controllers;

internal class NewspaperController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Name[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Issue Number[/]");

        var newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

        foreach (var newspaper in newspapers)
        {
            table.AddRow(
                $"[Red]{newspaper.Id.ToString()}[/]",
                $"[Cyan]{newspaper.Name}[/]",
                $"[Cyan]{newspaper.Publisher}[/]",
                $"[Green]{newspaper.PublishDate:MMMM dd, yyyy}[/]",
                $"[Blue]{newspaper.Location}[/]",
                $"[Red]{newspaper.IssueNumber.ToString()}[/]"
            );
        }
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public void AddItem()
    {
        var name = AnsiConsole.Ask<string>("Enter the [Green]Name[/] of the newspaper");
        var publisher = AnsiConsole.Ask<string>("Enter the [Green]Publisher[/] of the newspaper");
        var publishDate = AnsiConsole.Ask<DateTime>(
            "Enter the [Green]Publish Date[/] of the newspaper"
        );
        var location = AnsiConsole.Ask<string>("Enter the [Green]Location[/] of the newspaper");
        var issueNumbner = AnsiConsole.Ask<int>(
            "Enter the [Green]issue number[/] of the newspaper"
        );

        if (MockDatabase.LibraryItems.Any(m => m.Name.Equals(name)))
        {
            AnsiConsole.MarkupLine("[Red]This newspaper already exists![/]");
        }
        else
        {
            var newNewspaper = new Newspaper(
                MockDatabase.LibraryItems.Count + 1,
                name,
                publisher,
                publishDate,
                location,
                issueNumbner
            );
            MockDatabase.LibraryItems.Add(newNewspaper);
            AnsiConsole.MarkupLine($"[Green]{name}[/] Added succesfully!");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.Count == 0)
        {
            AnsiConsole.MarkupLine("No newspapers to Delete!");
            Console.ReadKey();
            return;
        }

        var newspaperToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Newspaper>()
                .Title("Select a newspaper to delete:")
                .UseConverter(m => $"{m.Name} by {m.Publisher}")
                .AddChoices(MockDatabase.LibraryItems.OfType<Newspaper>())
        );

        if (MockDatabase.LibraryItems.Remove(newspaperToDelete))
        {
            AnsiConsole.MarkupLine("[Green]Newspaper Deleted Succesfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[Red]Newspaper not found![/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue!");
        Console.ReadKey();
        Console.Clear();
    }
}

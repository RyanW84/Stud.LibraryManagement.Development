using Spectre.Console;
using Study.LibraryManagementApp.Ryanw84.Models;

namespace Study.LibraryManagementApp.Ryanw84.Controllers;

internal class MagazineController : BaseController, IBaseController
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

        var magazines = MockDatabase.LibraryItems.OfType<Magazine>();

        foreach (var magazine in magazines)
        {
            table.AddRow(
                $"[Red]{magazine.Id}[/]",
                $"[Cyan]{magazine.Name}[/]",
                $"[Cyan]{magazine.Publisher}[/]",
                $"[Green]{magazine.PublishDate:MMMM dd, yyyy}[/]",
                $"[Blue]{magazine.Location}[/]",
                $"[Red]{magazine.IssueNumber.ToString()}[/]"
            );
        }
        AnsiConsole.Write(table);
        DisplayMessage("Press Any Key to Continue.","Yellow");
        Console.ReadKey();
        Console.Clear();
    }

    public void AddItem()
    {
        var name = AnsiConsole.Ask<string>("Enter the [Green]Name[/] of the magazine");
        var publisher = AnsiConsole.Ask<string>("Enter the [Green]Publisher[/] of the magazine");
        var publishDate = AnsiConsole.Ask<DateTime>(
            "Enter the [Green]Publish Date[/] of the magazine (yyyy-mm-dd)"
        );
        var location = AnsiConsole.Ask<string>("Enter the [Green]Location[/] of the magazine");
        var issueNumbner = AnsiConsole.Ask<int>("Enter the [Green]issue number[/] of the magazine");

        if (MockDatabase.LibraryItems.Any(m => m.Name.Equals(name)))
        {
            AnsiConsole.MarkupLine("[Red]This magazine already exists![/]");
        }
        else
        {
            var newMagazine = new Magazine(
                MockDatabase.LibraryItems.Count + 1,
                name,
                publisher,
                publishDate,
                location,
                issueNumbner
            );
            MockDatabase.LibraryItems.Add(newMagazine);
            DisplayMessage($"{name} Added succesfully!", "Green");
        }

        DisplayMessage("Press any key to continue.","Yellow");
        Console.ReadKey();
        Console.Clear();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.Count == 0)
        {
            DisplayMessage("No magazines to Delete!" , "Red");
            Console.ReadKey();
            return;
        }

        var magazineToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Magazine>()
                .Title("Select a magazine to delete:")
                .UseConverter(m => $"{m.Name} by {m.Publisher}")
                .AddChoices(MockDatabase.LibraryItems.OfType<Magazine>())
        );
        if (ConfirmDeletion(magazineToDelete.Name))
        {
			if (MockDatabase.LibraryItems.Remove(magazineToDelete))
			{
				DisplayMessage("Magazine Deleted Succesfully" , "Green");
			}
			else
			{
				DisplayMessage("Magazine not found!" , "Red");
			}
            
		}
        else
        {
            DisplayMessage("Deletion Cancelled!" , "Red");
        }


            DisplayMessage("Press Any Key to Continue!" , "Yellow");
        Console.ReadKey();
        Console.Clear();
    }
}

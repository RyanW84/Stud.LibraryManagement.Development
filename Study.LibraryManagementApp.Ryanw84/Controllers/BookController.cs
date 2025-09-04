using Spectre.Console;
using Study.LibraryManagementApp.Ryanw84.Models;

namespace Study.LibraryManagementApp.Ryanw84.Controllers;

internal class BookController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDatabase.LibraryItems.OfType<Book>();

        foreach (var book in books)
        {
            table.AddRow(
                $"[Red]{book.Id}[/]",
                $"[Cyan]{book.Name}[/]",
                $"[Cyan]{book.Author}[/]",
                $"[Green]{book.Category}[/]",
                $"[Blue]{book.Location}[/]",
                $"[Red]{book.Pages}[/]"
            );
        }
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [Green]Title[/] of the book");
        var author = AnsiConsole.Ask<string>("Enter the [Green]Author[/] of the book");
        var category = AnsiConsole.Ask<string>("Enter the [Green]Category[/] of the book");
        var location = AnsiConsole.Ask<string>("Enter the [Green]Location[/] of the book");
        var pages = AnsiConsole.Ask<int>("Enter the [Green]number of pages[/] of the book");

        if (MockDatabase.LibraryItems.Any(b => b.Name.Equals(title)))
        {
            AnsiConsole.MarkupLine("[Red]This book already exists![/]");
        }
        else
        {
            var newBook = new Book(
                MockDatabase.LibraryItems.Count + 1,
                title,
                author,
                category,
                location,
                pages
            );
            MockDatabase.LibraryItems.Add(newBook);
            AnsiConsole.MarkupLine($"[Green]{title}[/] Added succesfully!");
        }

        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.Count == 0)
        {
            AnsiConsole.MarkupLine("No books to Delete!");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
                .Title("Select a book to delete:")
                .UseConverter(b => $"{b.Name} by {b.Author}")
                .AddChoices(MockDatabase.LibraryItems.OfType<Book>())
        );

        if (MockDatabase.LibraryItems.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[Green]Book Deleted Succesfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[Red]Book not found![/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue!");
        Console.ReadKey();
        Console.Clear();
    }
}

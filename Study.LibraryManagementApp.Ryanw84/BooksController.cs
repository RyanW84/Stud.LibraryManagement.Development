using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84;

internal class BooksController
{
    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        // Printing each book to the console with a loop
        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        /* Having the user press a key before continuing, or the menu
         wouldn't be visualisable */
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        var newBook = AnsiConsole.Ask<string>("Enter the name of the book to add:");
        MockDatabase.Books.Add(newBook);
        AnsiConsole.MarkupLine($"[green]{newBook} has been added to the library.[/]");
        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        if (MockDatabase.Books.Count is 0)
        {
            AnsiConsole.MarkupLine("No books to Delete!");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a book to delete:")
                .AddChoices(MockDatabase.Books)
        );
        MockDatabase.Books.Remove(bookToDelete);
        AnsiConsole.MarkupLine($"[red]{bookToDelete} has been removed from the library.[/]");
        AnsiConsole.MarkupLine("Press Any Key to Continue!");
        Console.ReadKey();
    }
}

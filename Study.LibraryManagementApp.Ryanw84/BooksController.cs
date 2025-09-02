using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84;

internal class BooksController
{
    internal void ViewBooks()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
		table.AddColumn("[yellow]Title[/]");
		table.AddColumn("[yellow]Author[/]");
		table.AddColumn("[yellow]Category[/]");
		table.AddColumn("[yellow]Location[/]");
		table.AddColumn("[yellow]Pages[/]");

        foreach (var book in MockDatabase.Books)
        {
            table.AddRow(
                book.Id.ToString() ,
                book.Name ,
                book.Author ,
                book.Category ,
                book.Location ,
                book.Pages.ToString()
                );
        }
        AnsiConsole.Write(table);
		AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [Green]Title[/]of the book");
		var author = AnsiConsole.Ask<string>("Enter the [Green]Author[/]of the book");
		var category = AnsiConsole.Ask<string>("Enter the [Green]Category[/]of the book");
		var location = AnsiConsole.Ask<string>("Enter the [Green]Location[/]of the book");
		var pages = AnsiConsole.Ask<int>("Enter the [Green]number of pages[/]of the book");

		if (MockDatabase.Books.Any(b=>b.Name.Equals(title)))
        {
            AnsiConsole.MarkupLine("[Red]This book already exists![/]");
        }
		else
		{
            var newBook = new Book(MockDatabase.Books.Count +1, title, author, category, location, pages );
            MockDatabase.Books.Add(newBook);
                AnsiConsole.MarkupLine($"[Gree]{title}[/] Added succesfully!");
		}

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
            new SelectionPrompt<Book>()
                .Title("Select a book to delete:")
                .UseConverter(b=> $"{b.Name} {b.Author}"
        ));
        MockDatabase.Books.Remove(bookToDelete);
        AnsiConsole.MarkupLine($"[red]{bookToDelete} has been removed from the library.[/]");
        AnsiConsole.MarkupLine("Press Any Key to Continue!");
        Console.ReadKey();
    }
}

using Spectre.Console;

List<string> books =
[
    "The Great Gatsby",
    "To Kill a Mockingbird",
    "1984",
    "Pride and Prejudice",
    "The Catcher in the Rye",
    "The Hobbit",
    "Moby-Dick",
    "War and Peace",
    "The Odyssey",
    "The Lord of the Rings",
    "Jane Eyre",
    "Animal Farm",
    "Brave New World",
    "The Chronicles of Narnia",
    "The Diary of a Young Girl",
    "The Alchemist",
    "Wuthering Heights",
    "Fahrenheit 451",
    "Catch-22",
    "The Hitchhiker's Guide to the Galaxy",
];

MainMenu();
void MainMenu()
{
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
                .Title("What do you want to do next?")
                .AddChoices(Enum.GetValues<MenuOption>())
        );

        switch (choice)
        {
            case MenuOption.ViewBooks:
                ViewBooks();
                break;
            case MenuOption.AddBook:
                AddBook();
                break;
            case MenuOption.DeleteBook:
                DeleteBook();
                break;
        }
    }
}
void AddBook()
{
    var newBook = AnsiConsole.Ask<string>("Enter the name of the book to add:");
    books.Add(newBook);
    AnsiConsole.MarkupLine($"[green]{newBook} has been added to the library.[/]");
    AnsiConsole.MarkupLine("Press any key to continue.");
    Console.ReadKey();
}

void ViewBooks()
{
    AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

    // Printing each book to the console with a loop
    foreach (var book in books)
    {
        AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
    }

    /* Having the user press a key before continuing, or the menu
     wouldn't be visualisable */
    AnsiConsole.MarkupLine("Press Any Key to Continue.");
    Console.ReadKey();
}

void DeleteBook()
{
    if (books.Count is 0)
    {
        AnsiConsole.MarkupLine("No books to Delete!");
        Console.ReadKey();
        return;
    }

    var bookToDelete = AnsiConsole.Prompt(
        new SelectionPrompt<string>().Title("Select a book to delete:").AddChoices(books)
    );
    books.Remove(bookToDelete);
    AnsiConsole.MarkupLine($"[red]{bookToDelete} has been removed from the library.[/]");
    AnsiConsole.MarkupLine("Press Any Key to Continue!");
    Console.ReadKey();
}

enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook,
}

using Spectre.Console;

// field
List<string> books =
[
    "book1", "book2", "book3", "book4", "book5", "book6",
    "book7", "book8", "book9", "book10", "book11", "book12", "book13", "book14", "book15",
    "book16", "book17", "book18", "book19", "book20"
];

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOption>()
            .Title("What would you like to do next?")
            .AddChoices(Enum.GetValues<MenuOption>())
    );

    switch (choice)
    {
        case MenuOption.ViewBooks:
            AnsiConsole.MarkupLine("[bold yellow]List of Books:[/]");
            foreach (var book in books) AnsiConsole.MarkupLine($"[cyan]{book}[/]");
            AnsiConsole.MarkupLine("Press any key to continue...");
            Console.ReadKey();
            break;
        case MenuOption.AddBook:
            AnsiConsole.MarkupLine("[bold red]You can add the book.[/]");
            break;
        case MenuOption.DeleteBook:
            AnsiConsole.MarkupLine("[bold red]You can delete the book.[/]");
            break;
    }
}

internal enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook
}
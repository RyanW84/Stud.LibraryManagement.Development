using Spectre.Console;

while (true)
{
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOption>()
            .Title("What would you like to do next?")
            .AddChoices(Enum.GetValues<MenuOption>())
    );

    switch (choice)
    {
        case MenuOption.ViewBooks:
            AnsiConsole.MarkupLine("[bold red]You can view the books below.[/]");
            break;
        case MenuOption.AddBook:
            AnsiConsole.MarkupLine("[bold red]You can add the book.[/]");
            break;
        case MenuOption.DeleteBook:
            AnsiConsole.MarkupLine("[bold red]You can delete the book.[/]");
            break;
    }
}

enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook,
}
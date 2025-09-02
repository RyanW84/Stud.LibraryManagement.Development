﻿using Spectre.Console;
using static Study.LibraryManagementApp.Ryanw84.Enums;

namespace Study.LibraryManagementApp.Ryanw84;

internal class UserInterface
{
    BooksController booksController = new();

    internal void MainMenu()
    {
       
        while (true)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<MenuOption>())
            );

            switch (choice)
            {
                case MenuOption.ViewBooks:
                    booksController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    booksController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    booksController.DeleteBook();
                    break;
            }
        }
    }
}

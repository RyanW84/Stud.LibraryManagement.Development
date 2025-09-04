using Spectre.Console;

using Study.LibraryManagementApp.Ryanw84.Controllers;

using static Study.LibraryManagementApp.Ryanw84.Enums;

namespace Study.LibraryManagementApp.Ryanw84;

internal class UserInterface
{
	private readonly BookController _bookController = new();
	private readonly MagazineController _magazineController = new();
	private readonly NewspaperController _newspaperController = new();

	internal void MainMenu( )
	{

		while (true)
		{
			Console.Clear();
			var actionChoice = AnsiConsole.Prompt(
				new SelectionPrompt<MenuAction>()
					.Title("What do you want to do next?")
					.AddChoices(Enum.GetValues<MenuAction>())
			);

			var itemTypeChoice = AnsiConsole.Prompt(
				  new SelectionPrompt<ItemType>()
					  .Title("Select the type of item:")
					  .AddChoices(Enum.GetValues<ItemType>())
			  );




			switch (actionChoice)
			{
				case MenuAction.ViewItem:
					ViewItems(itemTypeChoice);
					break;
				case MenuAction.AddItem:
					AddItem(itemTypeChoice);
					break;
				case MenuAction.DeleteItem:
					DeleteItem(itemTypeChoice);
					break;
				default:
					AnsiConsole.MarkupLine("Please Enter a valid choice!");
					break;
			}
		}
	}


	private void ViewItems(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				_bookController.ViewItems();
				break;
			case ItemType.Magazine:
				_magazineController.ViewItems();
				break;
			case ItemType.Newspaper:
				_newspaperController.ViewItems();
				break;
			default:
				AnsiConsole.MarkupLine("Please enter a valid choice");
				break;
		}
	}
	private void AddItem(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				_bookController.AddItem();
				break;
			case ItemType.Magazine:
				_magazineController.AddItem();
				break;
			case ItemType.Newspaper:
				_newspaperController.AddItem();
				break;
			default:
				AnsiConsole.MarkupLine("Please enter a valid choice");
				break;
		}
	}
	private void DeleteItem(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				_bookController.DeleteItem();
				break;
			case ItemType.Magazine:
				_magazineController.DeleteItem();
				break;
			case ItemType.Newspaper:
				_newspaperController.DeleteItem();
				break;
			default:
				AnsiConsole.MarkupLine("Please enter a valid choice");
				break;
		}
	}
}



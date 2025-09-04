using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84.Controllers;
internal abstract class BaseController
{
	protected void DisplayMessage(string message , string colour = "Yellow")
	{
		AnsiConsole.MarkupLine($"[{colour}]{message}[/]");
	}

	protected bool ConfirmDeletion(string itemName)
	{
		var confirm =AnsiConsole.Confirm($"Are you sure you want to delete [Red]{itemName}[/]?");
		return confirm;
	}
}

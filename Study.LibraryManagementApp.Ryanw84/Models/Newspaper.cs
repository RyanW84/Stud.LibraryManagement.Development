using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84.Models;

internal class Newspaper(
    int id,
    string name,
    string publisher,
    DateTime publishDate,
    string location,
    int issueNumber
) : LibraryItem(id, name, location)
{
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public int IssueNumber { get; set; }

	public void DisplayDetails( )
	{
		var panel = new Panel(
			new Markup($"[bold]Magazine:[/] [Cyan]{Name}[/] Published by [Cyan]{Publisher}[/]")
				+ $"\n[Bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}"
				+ $"\n[Bold]Issue Number:[/] [Blue]{Location}[/]"
				+ $"\n[Bold]Location:[/] [Green]{IssueNumber}"
		)
		{
			Border = BoxBorder.Rounded ,
		};
		AnsiConsole.Write(panel);
	}
}

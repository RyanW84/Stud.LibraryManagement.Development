using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84.Models;

internal class Magazine(
    int id,
    string name,
    string publisher,
    DateTime publishDate,
    string location,
    int issueNumber
) : LibraryItem(id, name, location)
{
    public string Publisher { get; set; } = publisher;
    public DateTime PublishDate { get; set; } = publishDate;
    public int IssueNumber { get; set; } = issueNumber;


	public override void DisplayDetails()
    {
        var panel = new Panel(
            new Markup($"[bold]Magazine:[/] [Cyan]{Name}[/] Published by [Cyan]{Publisher}[/]")
                + $"\n[Bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}"
                + $"\n[Bold]Issue Number:[/] [Blue]{IssueNumber}[/]"
                + $"\n[Bold]Location:[/] [Green]{Location}"
        )
        {
            Border = BoxBorder.Rounded,
        };
        AnsiConsole.Write(panel);
    }
	public override decimal CalculatePrice( )
	{
		return _price = 2;
	}

	public override decimal CalculatePrice(decimal discount)
	{
		return _price - discount;
	}

	public override decimal CalculatePrice(decimal discount , decimal taxRate)
	{
		taxRate = 0.20m; // 20%
		decimal priceAfterDiscount = _price - discount;
		return priceAfterDiscount * taxRate;
	}
}

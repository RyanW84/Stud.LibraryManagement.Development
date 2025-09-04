using Spectre.Console;

namespace Study.LibraryManagementApp.Ryanw84.Models;

internal class Book(int id, string name, string author, string category, string location, int pages)
    : LibraryItem(id, name, location)
{
    public string Author { get; set; } = author;
    public string Category { get; set; } = category;
    public int Pages { get; set; } = pages;

    public override void DisplayDetails()
    {
        var panel = new Panel(
            new Markup($"[bold]Book:[/] [Cyan]{Name}[/] by [Cyan]{Author}[/]")
                + $"\n[Bold]Category:[/] [Green]{Category}[/]"
                + $"\n[Bold]Location:[/] [Blue]{Location}[/]"
                + $"\n[Bold]Pages:[/] {Pages}"
        )
        {
            Border = BoxBorder.Rounded,
        };
        AnsiConsole.Write(panel);
    }

    public override decimal CalculatePrice()
    {
        return _price = 2;
    }

    public override decimal CalculatePrice(decimal discount)
    {
        return _price - discount;
    }

    public override decimal CalculatePrice(decimal discount, decimal taxRate)
    {
        taxRate = 0.20m; // 20%
        decimal priceAfterDiscount = _price - discount;
        return priceAfterDiscount * taxRate;
    }
}

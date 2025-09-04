namespace Study.LibraryManagementApp.Ryanw84.Models;

internal abstract class LibraryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    protected decimal _price;

    protected LibraryItem(int id, string name, string location)
    {
        Id = id;
        Name = name;
        Location = location;

        _price = 10.0m;
    }

    public abstract void DisplayDetails();

    public abstract decimal CalculatePrice();
    public abstract decimal CalculatePrice(decimal discount);
    public abstract decimal CalculatePrice(decimal discount , decimal taxRate);
}

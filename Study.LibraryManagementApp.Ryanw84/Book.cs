namespace Study.LibraryManagementApp.Ryanw84;

internal class Book
{
    string Name;
    string Location;

    internal Book()
    {
        Console.WriteLine("Book name is Unknown!");
    }

    internal Book(string name)
    {
        Name = name;
        Console.WriteLine($"Book name: {name} and location is unknown");
    }

    internal Book(string name, string location)
    {
        Name = name;
        Location = location;
        Console.WriteLine($"Book Name: {name} and Location: {location}");
    }
}

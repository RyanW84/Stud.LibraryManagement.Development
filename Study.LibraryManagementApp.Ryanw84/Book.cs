namespace Study.LibraryManagementApp.Ryanw84;

internal class Book // Model - object with multiple properties
{
    //string _name;
    //string Location;

    //public string Name // Backing field - private and accessed through properties
    //{
    //    get { return _name; }
    //    set
    //    {
    //        if (string.IsNullOrEmpty(value)) // Validation added in one place
    //        {
    //            throw new ArgumentNullException(value);
    //        }
    //        _name = value; // Sets the value from outside the class
    //    }
    //}

    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public int Pages { get; set; }

    internal Book(int id, string name, string author, string category, string location, int pages)
    {
        Id = id;
        Name = name;
        Author = author;
        Category = category;
        Location = location;
        Pages = pages;
    }
}

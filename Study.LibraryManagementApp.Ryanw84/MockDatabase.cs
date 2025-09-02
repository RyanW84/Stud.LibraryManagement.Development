using System.Data.Common;

namespace Study.LibraryManagementApp.Ryanw84;

internal class MockDatabase
{
    internal static List<Book> Books =
	[
		new Book(1, "Book A", "Author A", "Category A", "A1", 218),
        new Book(1, "Book B", "Author B", "Category B", "B1", 12),
        new Book(1, "Book C", "Author C", "Category C", "C1", 132),
        new Book(1, "Book D", "Author D", "Category D", "D1", 43),
        new Book(1, "Book E", "Author E", "Category E", "E1", 344),
    ];

  

}

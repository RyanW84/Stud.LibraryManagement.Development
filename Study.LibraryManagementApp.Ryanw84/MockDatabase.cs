using Study.LibraryManagementApp.Ryanw84.Models;

namespace Study.LibraryManagementApp.Ryanw84;

internal class MockDatabase
{
	internal static List<LibraryItem> LibraryItems =
	[
        // Books
        new Book(1, "Book 1", "Author 1", "Category 1", "B1", 1),
		new Book(2, "Book 2", "Author 2", "Category 2", "B2", 2),
		new Book(3, "Book 3", "Author 3", "Category 3", "B3", 3),
		new Book(4, "Book 4", "Author 4", "Category 4", "B4", 4),
		new Book(5, "Book 5", "Author 5", "Category 5", "B5", 5),
        // Magazines
        new Magazine(1, "Magazine 1", "Publisher 1", new DateTime(2025, 01, 01), "M1", 1),
		new Magazine(2, "Magazine 2", "Publisher 2", new DateTime(2025, 01, 01), "M2", 2),
		new Magazine(3, "Magazine 3", "Publisher 3", new DateTime(2025, 01, 01), "M3", 3),
		new Magazine(4, "Magazine 4", "Publisher 4", new DateTime(2025, 01, 01), "M4", 4),
		new Magazine(5, "Magazine 5", "Publisher 5", new DateTime(2025, 01, 01), "M5", 5),
        // Newspapers
        new Newspaper(1, "Newspaper 1", " News Publisher 1", new DateTime(2025, 01, 01), "N1", 1),
		new Newspaper(2, "Newspaper 2", " News Publisher 2", new DateTime(2025, 01, 01), "N2", 2),
		new Newspaper(3, "Newspaper 3", " News Publisher 3", new DateTime(2025, 01, 01), "N3", 3),
		new Newspaper(4, "Newspaper 4", " News Publisher 4", new DateTime(2025, 01, 01), "N4", 4),
		new Newspaper(5, "Newspaper 5", " News Publisher 5", new DateTime(2025, 01, 01), "N5", 5),
	];
}

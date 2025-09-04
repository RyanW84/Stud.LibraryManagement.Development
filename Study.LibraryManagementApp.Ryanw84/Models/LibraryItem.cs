﻿namespace Study.LibraryManagementApp.Ryanw84.Models;

internal abstract class LibraryItem(int id , string name , string location)
{
	public int Id { get; set; } = id;
	public string Name { get; set; } = name;
	public string Location { get; set; } = location;
}

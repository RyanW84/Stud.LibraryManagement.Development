using Study.LibraryManagementApp.Ryanw84;

//UserInterface userInterface = new();
//userInterface.MainMenu();

public abstract class Animal
{
public int Id { get; set; }
}
public interface AnimalActions
{
	void GetSound( );
}

public class Bird : Animal
{

}
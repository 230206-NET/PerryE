namespace Models;

public class Employee : IUser
{
    public Employee() : base ()
    {
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Something or other");
    }
}
namespace UI;
public class MainScreen{
    public MainScreen(string userName, string Role){
        int choice;
        Console.WriteLine($"Hello {userName}. Please select one of the activities listed below");
        Console.WriteLine("\n[1] View Existing Tickets");
        if (Role == "Employee"){
            Console.WriteLine("\n[2] Submit New Ticket");
        } else{
            Console.WriteLine("\n[2] Employee Management");
        }
        Console.WriteLine("\n[3] Edit Personal Information");
        Console.WriteLine("\n[4] Exit Application");
        string? option = Console.ReadLine();
    }
}
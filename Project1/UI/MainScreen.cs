using Models;
namespace UI;
public class MainScreen{
    public MainScreen(User user){
        bool runProgram = true;
        while (runProgram){
        int choice;
        Console.WriteLine($"Hello {user.UserName}. Please select one of the activities listed below");
        Console.WriteLine("\n[1] View Existing Tickets");
        if (user.Role == "Employee"){
            Console.WriteLine("\n[2] Submit New Ticket");
        } else{
            Console.WriteLine("\n[2] Employee Management");
        }
        Console.WriteLine("\n[3] Edit Personal Information");
        Console.WriteLine("\n[4] Exit Application");
        string? option = Console.ReadLine();
        switch (option){
            case "1":
                if (user.Role == "Employee"){
                    new EmployeeTicketView(user.UserId);
                }
                if (user.Role == "Manager"){
                    new ManagerTickets();
                    }
                break;
            case "2":
                if (user.Role == "Manager"){
                    new EmployeeAdminScreen();
                    break;
                }
                break;
            case "3":
                break;
            case "4":
                runProgram = false;
                break;
            default:
                Console.WriteLine("Invalid Input. Please try again");
                break;
        }
    }
    }
}
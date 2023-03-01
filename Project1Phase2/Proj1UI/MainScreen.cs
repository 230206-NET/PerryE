using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class MainScreen{
    HttpClient _http;
    public MainScreen(HttpClient http){
        _http = http;

    }
    public async Task MainScreenView(IUser user){
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
        Console.WriteLine("\n[0] Exit Application");
       string? option = Console.ReadLine();
        switch (option){
            case "1":
                if (user.Role == "Employee"){
                    await new EmployeeTicketView(_http).showTickets(user);
                }
                if (user.Role == "Manager"){
                    await new ManagerTickets(_http).TicketView(user);
                    }
                break;
            case "2":
                if (user.Role == "Manager"){
                    await new EmployeeAdminScreen(_http).EmployeeScreen(user);
                    break;
                } else{
                    await new SubmitTicket(_http).TicketSubmission(user);
                }
                break;
            case "3":
                new ChangeInfo(user);
                break;
            case "0":
                runProgram = false;
                break;
            default:
                Console.WriteLine("Invalid Input. Please try again");
                break;
        }
    }
    }
}
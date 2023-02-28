using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class EmployeeAdminScreen{
public EmployeeAdminScreen(IUser user){
    while (true){
    Console.WriteLine("Welcome to the Employee Admin Screen");
    Console.WriteLine("User ID | User Full Name | User username");
    Console.WriteLine("==========================================\n");
    List<IUser> employees = DBAccess.getEmployees();
    foreach (IUser employee in employees){
        Console.WriteLine($"{employee.UserId} | {employee.FirstName} {employee.LastName} | {employee.UserName}");
    }
    Console.WriteLine("If you would like to make an employee a manager, please type in the user ID");
    Console.WriteLine("To return to the main menu, enter 0");
    int chosen;
    bool option = int.TryParse(Console.ReadLine()!, out chosen);
    if (chosen == 0){
        break;
    }
    else if (option == false){ 
        Console.WriteLine("Invalid input");
    } else{
        DBAccess.changeUserField("User_Position", chosen, "Manager");
    }
    }

}
}
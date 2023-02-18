using Models;
using DataAccess;
namespace UI;
using services;
public class EmployeeAdminScreen{
public EmployeeAdminScreen(){
    while (true){
    Console.WriteLine("Welcome to the Employee Admin Screen");
    Console.WriteLine("User ID | User Full Name | User username");
    Console.WriteLine("==========================================\n");
    List<User> employees = Service.filterForEmployees();
    foreach (User employee in employees){
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
        Service.makeEmployeeManager(chosen);
    }
    }

}
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using Models;

namespace UI;
public class EmployeeAdminScreen{
    private static HttpClient _http;
    public EmployeeAdminScreen(HttpClient http){
        _http = http;
    }
public async Task EmployeeScreen(IUser user){
    while (true){
    Console.WriteLine("Welcome to the Employee Admin Screen");
    Console.WriteLine("User ID | User Full Name | User username");
    Console.WriteLine("==========================================\n");
    try{
    string content = await _http.GetStringAsync("users");
    List<IUser> employees = JsonSerializer.Deserialize<List<IUser>>(content);
    foreach (IUser employee in employees){
        Console.WriteLine($"{employee.UserId} | {employee.FirstName} {employee.LastName} | {employee.UserName}");
    }
    } catch (Exception e){
        Console.WriteLine("Cannot find any users. This may be because of a lack of users in the database or an inability to query the database");
        return;
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
        try{
        _http.PostAsync("/users/MakeManager/" + chosen, null);
        } catch (Exception e){
            Console.WriteLine("An error occurred while trying to prmote the specified user. Pleases try again");
        }
    }
    }

}
}
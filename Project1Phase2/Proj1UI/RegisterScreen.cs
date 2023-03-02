using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using Models;


namespace UI;
public class Register
{
    private string UserFirstName;
    private string UserLastName;
    private string NewUserName;
    private string UserPassword;
    private string UserPhoneNumber;
    private HttpClient _http;
    public Register(HttpClient http){
        _http = http;
    }
    public async Task RegisterScreen()
    {
        promptForName();
        await promptForCredentials();
        promptForPhoneNumber();
        await RegisterUser();
    }
    private async Task RegisterUser()
{
    JsonContent content = JsonContent.Create<IUser>(new IUser(NewUserName, UserPassword, UserFirstName, UserLastName, UserPhoneNumber, "Employee"));
    await _http.PostAsync("/users/register", content);
    }

    private async Task<bool> checkForUsername(string userName){
        string content = await _http.GetStringAsync("/username?username={userName}");
        List<IUser> users = JsonSerializer.Deserialize<List<IUser>>(content);
        return users == null;
    }
    private void promptForName(){
        Console.WriteLine("Please Enter your first name");
        UserFirstName = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Last Name");
        UserLastName = Console.ReadLine()!;
    }
    private async Task promptForCredentials(){
        Console.WriteLine("Please Enter your desired Username");
        NewUserName = Console.ReadLine()!;
        while(!await checkForUsername(NewUserName)){
            Console.WriteLine("Username taken. Please try another username");
            NewUserName = Console.ReadLine()!;
        }
        Console.WriteLine("Please Enter your Password"); 
        UserPassword = Console.ReadLine()!;

    }
    private void promptForPhoneNumber(){
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        UserPhoneNumber = Console.ReadLine()!;
    }
}
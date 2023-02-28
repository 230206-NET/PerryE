using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class Register{
    private string fullName;
    private string username;
    private string hashedPassword;
    private string phoneNumber;
    private HttpClient _http;
    public Register(){
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5184/");
        promptForName();
        promptForCredentials();
        promptForPhoneNumber();
        DBAccess.CreateNewUser(username, hashedPassword, fullName, phoneNumber);
    }
    private async bool checkForUsername(string userName){
        if (DBAccess.GetUserByUsername(userName) == null){
        return true;
        } else{
            return false;
        }
    }
    private void promptForName(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine()!;
        fullName = firstName + " " + lastName;
    }
    private void promptForCredentials(){
        Console.WriteLine("Please Enter your desired Username");
        username = Console.ReadLine()!;
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine()!;
        }
        Console.WriteLine("Please Enter your Password"); 
        string password = Console.ReadLine()!;
        hashedPassword = PasswordHelper.HashAndSaltPassword(password);

    }
    private void promptForPhoneNumber(){
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        phoneNumber = Console.ReadLine()!;
    }
}
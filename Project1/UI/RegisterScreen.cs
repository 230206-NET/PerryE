using System;
using System.Net.Http;
using System.Threading.Tasks;
using Models;


namespace UI;
public class Register
{
    private string firstName;
    private string lastName;
    private string username;
    private string hashedPassword;
    private string phoneNumber;
    private readonly IHttpClientFactory _httpClientFactory;

    public async Task Register(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        promptForName();
        await promptForCredentials();
        promptForPhoneNumber();
        await RegisterUser();
    }
    private async Task RegisterUser()
{
    var client = _httpClientFactory.CreateClient();
    var response = await client.PostAsJsonAsync("/users/register", new IUser
    {
        Username = username,
        Password = hashedPassword,
        firstName = firstName,
        lastName = lastName,
        PhoneNumber = phoneNumber,
        Role = "Employee"
    });
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("User registration successful");
    }
    else
    {
        Console.WriteLine("User registration failed");
    }
    }

    private async Task<bool> checkForUsername(string userName){
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("/username?username={userName}");
        if (response.IsSuccessStatusCode){
            var user = await response.Content.ReadAsAsync<User>();
            return user == null;
        }
        else
        {
            return false;
        }
    }
    private void promptForName(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine()!;
    }
    private async Task promptForCredentials(){
        Console.WriteLine("Please Enter your desired Username");
        username = Console.ReadLine()!;
        while(!await checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine()!;
        }
        Console.WriteLine("Please Enter your Password"); 
        string password = Console.ReadLine()!;

    }
    private void promptForPhoneNumber(){
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        phoneNumber = Console.ReadLine()!;
    }
}
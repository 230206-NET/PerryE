using System.Collections.Generic;
using DataAccess;
using Models;
using services;
namespace UI;
class LogInScreen{
    private HttpClient _http;
    public LogInScreen(HttpClient http){
        _http = http;
        IUser? logInInfo = getLoginInfo();
        bool loggedIn = (logInInfo != null);
        if (loggedIn){
            new MainScreen(_http, logInInfo);
        }
        else{
            Console.WriteLine("Incorrect Credentials");
        }
    }
    private IUser? getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        string userContent = _http.GetStringAsync("users/Login");
        IUser user = JsonSerializer.Deserialize<IUser>(userContent);
        return user;
        name, password);
    }
}
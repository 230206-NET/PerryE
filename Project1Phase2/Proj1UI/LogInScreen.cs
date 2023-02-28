using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using services;

using System.Text.Json;

namespace UI;
class LogInScreen{
    public LogInScreen(){
        IUser? logInInfo = getLoginInfo();
        bool loggedIn = (logInInfo != null);
        if (loggedIn){
            new MainScreen(logInInfo);
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
        return LogInHelper.LogIn(username, password);
    }
}
using System.Collections.Generic;
using DataAccess;
using Models;
using services;
namespace UI;
class LogInScreen{
    public LogInScreen(){
        User? logInInfo = getLoginInfo();
        bool loggedIn = (logInInfo != null);
        if (loggedIn){
            new MainScreen(logInInfo);
        }
        else{
            Console.WriteLine("Incorrect Credentials");
        }
    }
    private User? getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        return LogInHelper.LogIn(username, password);
    }
}
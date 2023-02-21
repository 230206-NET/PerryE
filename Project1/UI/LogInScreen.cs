using System.Collections.Generic;
using DataAccess;
using Models;
using services;
namespace UI;
class LogInScreen{
    public LogInScreen(){
        User logInInfo = getLoginInfo();
        bool loggedIn = false;
        if (logInInfo != null){
            loggedIn = true;
            new MainScreen(logInInfo);
        }
        if (loggedIn == false){
            Console.WriteLine("Incorrect Credentials");
        }
    }
    private User getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        if (PasswordHelper.Login(username, password)){
            return DBAccess.GetUserByUsername(username);
        } else{
            return null;
        }
    }
}
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
    public User getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        User user = FileStorage.getSpecifiedUser(username);
        if (PasswordHelper.Login(username, password)){
            return FileStorage.GetUserByUsername(username);
        } else{
            return null;
        }
    }
}
using System.Collections.Generic;
using DataAccess;
using Models;
namespace UI;
class LogInScreen{
    public LogInScreen(){
        IUser logInInfo = getLoginInfo();
        bool loggedIn = false;
        if (logInInfo != null){
            loggedIn = true;
            new MainScreen(logInInfo);
        }
        if (loggedIn == false){
            Console.WriteLine("Incorrect Credentials");
        }
    }
    public IUser getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        IUser user = FileStorage.getSpecifiedUser(username, password);
        return user;
    }
}
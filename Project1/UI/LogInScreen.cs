using System.Collections.Generic;
using DataAccess;
using Models;
namespace UI;
class LogInScreen{
    public LogInScreen(){
        Console.WriteLine("Please enter you username");
        string? username = Console.ReadLine().Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine().Trim();
        List<IUser> userList = FileStorage.getUser();
        foreach (IUser user in userList){
            if (user.UserName == username && user.HashedPassword == password){
                new MainScreen(username, user.Role);
            }
        }
        Console.WriteLine("Invalid Credentials");
    }
}
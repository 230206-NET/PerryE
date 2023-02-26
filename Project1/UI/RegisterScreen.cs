using System.Security.Cryptography;
using Models;
using DataAccess;
using services;
namespace UI;
public class Register{

    private bool checkForUsername(string userName){
        if (DBAccess.GetUserByUsername(userName) == null){
        return true;
        } else{
            return false;
        }
    }
    public Register(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine()!;
        Console.WriteLine("Please Enter your desired Username");
        string username = Console.ReadLine()!;
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine()!;
        }
        Console.WriteLine("Please Enter your Password");
        //Eventually, add code here to hash the password before passing it to the database
        string password = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        //Needs a RegEx to ensure the phone number is valid
        string phoneNumber = Console.ReadLine()!;
        string hashedPassword = PasswordHelper.HashAndSaltPassword(password);
        DBAccess.CreateNewUser(username, hashedPassword, firstName + " " + lastName, phoneNumber);
    }
}
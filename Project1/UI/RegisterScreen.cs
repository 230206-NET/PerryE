using System.Security.Cryptography;
using Models;
using DataAccess;
using services;
namespace UI;
public class Register{
    public bool createNewUser(string firstName, string lastName, string username, string password, string phoneNumber){
        //Write code here that allows for the user to be created
        FileStorage.CreateNewUser(username, password, firstName + " " + lastName, phoneNumber);
        return true;
    }
    public bool checkForUsername(string userName){
        List<User> users = FileStorage.getUser();
        foreach(User user in users){
            if (user.UserName == userName){
                return false;
            }
        }
        return true;
    }
    public Register(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Please Enter your desired Username");
        string username = Console.ReadLine()!;
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine();
        }
        Console.WriteLine("Please Enter your Password");
        //Eventually, add code here to hash the password before passing it to the database
        string password = Console.ReadLine()!;
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        //Needs a RegEx to ensure the phone number is valid
        string phoneNumber = Console.ReadLine();
        string hashedPassword = PasswordHelper.HashAndSaltPassword(password);
        createNewUser(firstName, lastName, username, hashedPassword, phoneNumber);
    }
}
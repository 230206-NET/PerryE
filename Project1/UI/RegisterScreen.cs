using System.Security.Cryptography;
namespace UI;
public class Register{
    public bool createNewUser(string firstName, string lastName, string username, string password, string phoneNumber){
        //Write code here that allows for the user to be created
        return true;
    }
    public bool checkForUsername(string userName){
        //Write code here to make sure the username is unique
        return true;
    }
    public Register(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your desired Username");
        string username = Console.ReadLine()!.Trim();
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine()!.Trim();
        }
        Console.WriteLine("Please Enter your Password");
        //Eventually, add code here to hash the password before passing it to the database
        string password = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        //Needs a RegEx to ensure the phone number is valid
        string phoneNumber = Console.ReadLine()!.Trim();
        createNewUser(firstName, lastName, username, password, phoneNumber);
    }
}
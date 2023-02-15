using System.Security.Cryptography;
using Models;
using DataAccess;
namespace UI;
public class Register{
    public bool createNewUser(string firstName, string lastName, string username, string password, string phoneNumber){
        //Write code here that allows for the user to be created
        FileStorage.createNewUser(new Employee(15, username, password, firstName, lastName, phoneNumber, "Employee"));
        return true;
    }
    public bool checkForUsername(string userName){
        List<IUser> users = FileStorage.getUser();
        foreach(IUser user in users){
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
        string username = Console.ReadLine();
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username");
            username = Console.ReadLine();
        }
        Console.WriteLine("Please Enter your Password");
        //Eventually, add code here to hash the password before passing it to the database
        string password = Console.ReadLine();
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        //Needs a RegEx to ensure the phone number is valid
        string phoneNumber = Console.ReadLine();
        createNewUser(firstName, lastName, username, password, phoneNumber);
    }
}
namespace UI;
public class Register{
    public Register(){
        Console.WriteLine("Please Enter your first name");
        string firstName = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your Last Name");
        string lastName = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your desired Username");
        string username = Console.ReadLine()!.Trim();
        //Write code here to check that the username is not taken. If it is, require the user to enter a new username until they have a unique username
        Console.WriteLine("Please Enter your Password");
        //Eventually, add code here to hash the password before passing it to the database
        string password = Console.ReadLine()!.Trim();
        Console.WriteLine("Please Enter your Phone Number (No parentheses, dashes or spaces)");
        //Needs a RegEx to ensure the phone number is valid
        string phoneNumber = Console.ReadLine()!.Trim();
    }
}
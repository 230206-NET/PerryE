namespace UI;
class LogInScreen{
    public LogInScreen(){
        Console.WriteLine("Please enter you username");
        string? username = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
    }
}
namespace Models;

public class Employee : IUser
{
    public int UserId{get; set;}
    public string UserName{get;set;}
    public string HashedPassword{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public string CellNumber{get; set;}
    public string Role {get; set;}
    private IUser _User;

    public Employee(int userId, string userName, string hashedPassword, string firstName, string lastName, string cellNumber, string role)
    {
        UserId = userId;
        UserName = userName;
        HashedPassword = hashedPassword;
        FirstName = firstName;
        LastName = lastName;
        CellNumber = cellNumber;
        Role = role;
    }
        public Employee(string userName, string hashedPassword, string firstName, string lastName, string cellNumber)
    {
        UserName = userName;
        HashedPassword = hashedPassword;
        FirstName = firstName;
        LastName = lastName;
        CellNumber = cellNumber;
        Role = "Employee";
    }


    public void DisplayOptions()
    {
        Console.WriteLine("Something or other");
    }
}
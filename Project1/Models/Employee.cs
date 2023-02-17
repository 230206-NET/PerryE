
namespace Models;
public class Employee : IUser
{
    public string Role{get; set;}
    public string CellNumber{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public int UserId{get; set;}
    public string UserName { get; set; }
    public string HashedPassword { get; set;}

    public Employee(int userId, string cellNumber, string firstName, string lastName, string role, string userName, string hashedPassword) : base()
    {
        Role = role;
        CellNumber = cellNumber;
        FirstName = firstName;
        LastName = lastName;
        UserId = userId;
        UserName = userName;
        HashedPassword = hashedPassword;
    }



    public List<Ticket> getTickets(){
        //Implement Code that finds all tickets with the user's UserId
        return null!;

    }
    override public string ToString(){
        return this.FirstName + " " + this.LastName + " " + this.UserName;
    }
}

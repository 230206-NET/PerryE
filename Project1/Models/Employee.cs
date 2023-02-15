
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




    public Employee(int userId, string userName, string hashedPassword, string firstName, string lastName, string cellNumber, string role) : base(userId, userName, hashedPassword, firstName, lastName, cellNumber, role)
    {
        
    }

    public List<Ticket> getTickets(){
        //Implement Code that finds all tickets with the user's UserId
        return null!;

    }
    override public string ToString(){
        return this.FirstName + " " + this.LastName + " " + this.UserName;
    }
}

namespace Models;
public class Manager : IUser{
    public Manager(int userId, string userName, string hashedPassword, string firstName, string lastName, string cellNumber, string role) : base(userId, userName, hashedPassword, firstName, lastName, cellNumber, role)
    {
    }

    public string Role{get; set;}
    public string HashedPass{get; set;}
    public string CellNumber{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public int UserId{get; set;}
    public string UserName { get; set; }
    public string HashedPassword { get; set;}

    public List<Ticket> getTickets()
    {
        //In here, insert code that will return the outstanding tickets of all employees
        return null!;
    }
}
namespace Models;
public class Manager : IUser{
    public string Role{get; set;}
    public string HashedPass{get; set;}
    public double CellNumber{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public int UserId{get; set;}
    public string UserName { get; set; }
    public string HashedPassword { get; set;}
    public Manager(){
        //In here, initialize the values for all values using the database
    }
    public List<Ticket> getTickets()
    {
        //In here, insert code that will return the outstanding tickets of all employees
        return null!;
    }
}
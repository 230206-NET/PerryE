namespace Models;
public interface IUser
{
    public int UserId{get; set;}
    public string UserName{get;set;}
    public string HashedPassword{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public double CellNumber{get; set;}
    public string Role {get; set;}
    public List<Ticket> getTickets();

}

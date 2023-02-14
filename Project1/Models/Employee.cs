namespace Model;
public interface Employee
{
    public int UserId{get; set;}
    public string userName{get;set;}
    public string hashedPassword{get; set;}
    public string firstName{get; set;}
    public double CellNumber{get; set;}
    public string role {get; set;}
    public void getTickets();

}

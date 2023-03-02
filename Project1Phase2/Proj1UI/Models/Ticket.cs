namespace Models;
public class Ticket{
    public int TicketNum{get; set;}
    public double Amount{get; set;}
    public DateTime dateOfSubmission{get; set;}
    public int userId{get; set;}
    public string Username{get; set;}
    public string? status{get; set;}
    public string? Category{get; set;}

    public Ticket(int ticketNum, double amount, DateTime dateOfSubmission, int userId, string username, string status, string category)
    {
        TicketNum = ticketNum;
        Amount = amount;
        this.dateOfSubmission = dateOfSubmission;
        this.userId = userId;
        Username = username;
        this.status = status;
        Category = category;
    }
    public Ticket(double amount, int userId, string username, string category){
        this.dateOfSubmission = DateTime.Today;
        this.Amount = amount;
        this.userId = userId;
        this.Username = username;
        this.Category = category;
    }
    public Ticket(){}
}

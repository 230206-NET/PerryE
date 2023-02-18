namespace Models;
public class Ticket{
    public int TicketNum{get; set;}
    public double Amount{get; set;}
    public DateOnly dateOfSubmission{get; set;}
    public int userId{get; set;}
    public string Username{get; set;}
    public string? status{get; set;}
    public string? Category{get; set;}

    public Ticket(int ticketNum, double amount, DateOnly dateOfSubmission, int userId, string username, string status, string category)
    {
        TicketNum = ticketNum;
        Amount = amount;
        this.dateOfSubmission = dateOfSubmission;
        this.userId = userId;
        Username = username;
        this.status = status;
        Category = category;
    }
}

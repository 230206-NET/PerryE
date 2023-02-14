namespace Models;
public class Ticket{
    public int TicketNum{get; set;}
    public double Amount{get; set;}
    public DateOnly dateOfSubmission{get; set;}
    public int userId{get; set;}
    public string? status{get; set;}
    public string? Category{get; set;}

}

namespace Model;
public class Ticket{
    int TicketNum{get; set;}
    double Amount{get; set;}
    DateOnly dateOfSubmission{get; set;}
    int userId{get; set;}
    string? status{get; set;}
    string? Category{get; set;}

}

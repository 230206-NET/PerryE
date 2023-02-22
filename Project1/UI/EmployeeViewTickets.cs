using Models;
using services;
using DataAccess;

namespace UI;
class EmployeeTicketView{
    int UserId {set; get;}
    public EmployeeTicketView(User user){
        this.UserId = user.UserId;
        showTickets(user);
    }
    private void showTickets(User user){
        bool returnToHome = false;
        while(!returnToHome){
        Console.WriteLine("Hello. Please choose [1] if you would like to view currently pending tickets. [2] to view approved tickets. [3] to view denied tickets. [0] to return to Main Menu");
        string? option = Console.ReadLine();
        int choice;
        bool madeChoice = int.TryParse(option, out choice);
        switch (choice){
            case 1:
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Pending")){
                    Console.WriteLine(ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }

                break;
            case 2:
                Console.WriteLine("Fill in with past tickets view");
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Approved")){
                    Console.WriteLine(ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }
                break;
            case 3:
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Denied")){
                    Console.WriteLine(ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }
                break;
            case 0:
                returnToHome = true;
                break;
            default:
                break;
        }
        }
    }
}
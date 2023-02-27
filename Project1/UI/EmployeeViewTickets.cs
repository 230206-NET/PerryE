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
            Console.WriteLine("\n");
        Console.WriteLine("Hello. Please choose [1] if you would like to view currently pending tickets. [2] to view approved tickets. [3] to view denied tickets. [4] to view tickets based on specified category. [0] to return to Main Menu");
        string? option = Console.ReadLine();
        Console.WriteLine("\n");
        int choice;
        bool madeChoice = int.TryParse(option, out choice);
        switch (choice){
            case 1:
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Pending")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }

                break;
            case 2:
                Console.WriteLine("Fill in with past tickets view");
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Approved")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }
                break;
            case 3:
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Denied")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Amount);
                }
                break;
                case 4:
                    Console.WriteLine("Please enter the category you would like to search for");
                    Console.WriteLine("\n");
                    foreach(Ticket ticket in DBAccess.GetUserTicketsFromCategory(user.UserId, Console.ReadLine())){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount);
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
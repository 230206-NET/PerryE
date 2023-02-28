using Models;
using services;
using DataAccess;

namespace UI;
class EmployeeTicketView{
    int UserId {set; get;}
    public EmployeeTicketView(IUser user){
        this.UserId = user.UserId;
        showTickets(user);
    }
    private void showTickets(IUser user){
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
                Console.WriteLine("\n");
                        Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
        Console.WriteLine("===========================================================");
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Pending")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }

                break;
            case 2:
            Console.WriteLine("\n");
            Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
            Console.WriteLine("===========================================================");
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Approved")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }
                break;
            case 3:
                Console.WriteLine("\n");
                Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                Console.WriteLine("===========================================================");
                foreach(Ticket ticket in DBAccess.GetUserTicketsByStatus(user.UserId, "Denied")){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }
                break;
                case 4:
                    Console.WriteLine("Please enter category. \n");
                    string category = Console.ReadLine()!;
                    Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                    Console.WriteLine("===========================================================");
                    foreach(Ticket ticket in DBAccess.GetUserTicketsFromCategory(user.UserId, category)){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
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
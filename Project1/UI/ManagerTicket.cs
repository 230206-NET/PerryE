using Models;
using services;
using DataAccess;

namespace UI;
class ManagerTickets{
    private int UserId {get; set;}
    public ManagerTickets(User user)
{
    while(true){
        int ticketNum = SelectTicket();
        if (ticketNum == 0) break;
        ApproveOrDeny(ticketNum);
    }
}

private int SelectTicket()
{
    while(true){
        Console.WriteLine("#  |  Username  |  Submission Date  |  Amount  |  Category");
        Console.WriteLine("===========================================================");
    int ticketNum;
    List<Ticket> unapprovedTickets = DBAccess.GetAllUnapprovedTickets();
    foreach (Ticket ticket in unapprovedTickets){
        Console.WriteLine("\n" + ticket.TicketNum + "  |  " +  ticket.Username +  "  |  " + ticket.dateOfSubmission.ToShortDateString() + "  |  " + ticket.Amount + "  |  " + ticket.Category);
    }
    Console.WriteLine("Please Select a ticket number to approve or deny. To exit, please enter 0");
    bool validTicket = int.TryParse(Console.ReadLine(), out ticketNum);
    if (!validTicket) 
    {
        if (ticketNum == 0) break;
        Console.WriteLine("Invalid Input. Please Try Again");
        continue;
    }
    return ticketNum;
    }
    return 0;
}

private void ApproveOrDeny(int ticketNum)
{
    while (true)
    {
        Console.WriteLine("Would you like to approve [1] or deny [2] the reimbursement?");
        bool choiceMade = int.TryParse(Console.ReadLine(), out int choice);
        if (!choiceMade)
        {
            Console.WriteLine("Invalid Input. Please Try Again");
            continue; // repeat loop to prompt user again
        }
        if (choice == 1)
        {
            try{
                DBAccess.DecideOnTicket(ticketNum, "Approved");
                Console.WriteLine("The ticket has been approved");
                break;
            } catch(Exception e){
                Console.WriteLine("Invalid input. Please try again");
                continue;
            }
        } 
        else if (choice == 2)
        {
            try{
                DBAccess.DecideOnTicket(ticketNum, "Denied");
                Console.WriteLine("The ticket has been denied");
                break;
            } catch (Exception e){
                Console.WriteLine("Invalid Input. Please try again");
            }
        }
        else 
        {
            Console.WriteLine("Invalid Input. Please Try Again");
        }
    }
}
}
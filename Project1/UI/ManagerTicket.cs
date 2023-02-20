using Models;
using services;
using DataAccess;

namespace UI;
class ManagerTickets{
    private int UserId {get; set;}
    public ManagerTickets()
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
    int ticketNum;
    TicketHelper.displayAllPendingTickets();
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
                TicketHelper.approveTicket(ticketNum);
                break;
            } catch(Exception e){
                Console.WriteLine("Invalid input. Please try again");
                continue;
            }
        } 
        else if (choice == 2)
        {
            try{
                TicketHelper.denyTicket(ticketNum);
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
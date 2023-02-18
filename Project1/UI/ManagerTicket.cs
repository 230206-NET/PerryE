using Models;
using services;
using DataAccess;

namespace UI;
class ManagerTickets{
    private int UserId {get; set;}
    public ManagerTickets(){
        while(true){
            int ticketNum;
            TicketHelper.displayAllPendingTickets();
            Console.WriteLine("Please Select a ticket number to approve or deny. To exit, please enter 0");
            bool validTicket = int.TryParse(Console.ReadLine(), out ticketNum);
            if (validTicket){
                if (ticketNum == 0) break;
                while (true){
                    int choice;
                    Console.WriteLine("Would you like to approve [1] or deny [2] the reimbursement?");
                    bool choiceMade = int.TryParse(Console.ReadLine(), out choice);
                        if (choiceMade){
                            if (choice == 1){
                                TicketHelper.approveTicket(ticketNum);
                                break;
                            } else if (choice == 2){
                                TicketHelper.denyTicket(ticketNum);
                                break;
                            }
                            else Console.WriteLine("Invalid Input. Please Try Again");
                        } else{
                            Console.WriteLine("Invalid Input. Please Try Again");
                        }
                }

            } else{
                Console.WriteLine("Invalid Input. Please Try Again");
            }
        }
    }
}
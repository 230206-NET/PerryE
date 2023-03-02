using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace UI;
class ManagerTickets{
    private int UserId {get; set;}
    private HttpClient _http;
    public ManagerTickets(HttpClient http){
    _http = http;

    }
    public async Task TicketView(IUser user)
{
    while(true){
        Console.WriteLine("Press 1 to view all pending tickets. Press 2 to view tickets by user Id. Press 3 to view tickets by category. Press 0 to return to main menu.");
        int choice;
        string input = Console.ReadLine()!;
        bool successfulRead = int.TryParse(input, out choice);
        if (successfulRead && choice != 0){
            switch (choice){
                case 1:
                try{
                    int ticketNum = await SelectTicket();
                    if (ticketNum == 0) break;
                    await ApproveOrDeny(ticketNum);
                    break;

                } catch(Exception e){
                    Console.WriteLine("Unsuccessful. Please verify input");
                    break;
                }
                case 2:
                    Console.WriteLine("Please enter a user Id to search for all their tickets");
                    string userId = Console.ReadLine()!;
                    int numUserId;
                    bool userChoice = int.TryParse(userId, out numUserId);
                    try{
                    foreach (Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(await _http.GetStringAsync($"/ticket/{numUserId}"))){
                        Console.WriteLine("\n" + ticket.TicketNum + "  |  " +  ticket.Username +  "  |  " + ticket.dateOfSubmission.ToShortDateString() + "  |  " + ticket.Amount + "  |  " + ticket.Category + " | " + ticket.status);

                    }
                    Console.WriteLine("Please select a ticket to approve or deny. To exit, press 0");
                    string ticketNumeric = Console.ReadLine()!;
                    if (ticketNumeric == "0"){
                        break;
                    }
                    else{
                        int ticket;
                        int.TryParse(ticketNumeric, out ticket);
                        await ApproveOrDeny(ticket);
                        break;
                    }
                    } catch(Exception e){
                        Console.WriteLine("Error. Could not perform intended action");
                        break;
                    }
                case 3:
                    Console.WriteLine("Please enter the category you would like to search for");
                    string category = Console.ReadLine();
                    try{
                    foreach(Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(await _http.GetStringAsync($"/ticket/{category}"))){
                        Console.WriteLine("\n" + ticket.TicketNum + "  |  " +  ticket.Username +  "  |  " + ticket.dateOfSubmission.ToShortDateString() + "  |  " + ticket.Amount + "  |  " + ticket.Category + " | " + ticket.status);
                    }
                    Console.WriteLine("Please select a ticket to approve or deny. To exit, press 0");
                    string ticketNumber = Console.ReadLine()!;
                    if (ticketNumber == "0"){
                        break;
                    }
                    else{
                        int ticket;
                        int.TryParse(ticketNumber, out ticket);
                        await ApproveOrDeny(ticket);
                        break;

                    }
                    } catch(Exception e){
                        Console.WriteLine("No tickets found from that category.");
                        break;
                    }
            }

        } else if (choice == 0){
            break;
        }
    }
}

private async Task<int> SelectTicket()
{
    while(true){
        try{
        string content = await _http.GetStringAsync("/ticket");
        Console.WriteLine("#  |  Username  |  Submission Date  |  Amount  |  Category");
        Console.WriteLine("===========================================================");
        int ticketNum;
        foreach (Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(content)){
            Console.WriteLine("\n" + ticket.TicketNum + "  |  " +  ticket.Username +  "  |  " + ticket.dateOfSubmission.ToShortDateString() + "  |  " + ticket.Amount + "  |  " + ticket.Category);
        }
        Console.WriteLine("Please Select a ticket number to approve or deny. To exit, please enter 0");
        bool validTicket = int.TryParse(Console.ReadLine(), out ticketNum);
        if (!validTicket || ticketNum == 0) 
        {
            if (ticketNum == 0) break;
            Console.WriteLine("Invalid Input. Please Try Again");
            continue;
        }
        return ticketNum;

        } catch(Exception e){
            Console.WriteLine("Error. Please check your input");
            return 0;
        }
    }
}

private async Task ApproveOrDeny(int ticketNum)
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
                await _http.PostAsync($"/ticket/{ticketNum}/Approved", null);
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
                await _http.PostAsync($"/ticket/{ticketNum}/Denied", null);
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
using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using System.Text.Json;

namespace UI;
class EmployeeTicketView{
    HttpClient _http;
    int UserId {set; get;}
    public EmployeeTicketView(HttpClient http){
        _http = http;
    }
    public async Task showTickets(IUser user){
        bool returnToHome = false;
        while(!returnToHome){
            Console.WriteLine("\n");
        Console.WriteLine("Hello. Please choose [1] if you would like to view currently pending tickets. [2] to view approved tickets. [3] to view denied tickets. [4] to view tickets based on specified category. [0] to return to Main Menu");
        string? option = Console.ReadLine();
        Console.WriteLine("\n");
        int choice;
        string content;
        List<Ticket> tickets;
        bool madeChoice = int.TryParse(option, out choice);
        switch (choice){
            case 1:
                try{
                content = await _http.GetStringAsync($"/tickets/{user.UserId}/Pending");
                Console.WriteLine("\n");
                Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                Console.WriteLine("===========================================================");
                foreach(Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(content)){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }

                } catch (Exception e){
                    Console.WriteLine("No tickets found");
                } break;

            case 2:
            try{
                content = await _http.GetStringAsync($"/tickets/{user.UserId}/Approved");
                Console.WriteLine("\n");
                Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                Console.WriteLine("===========================================================");
                foreach (Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(content)) {
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }
            } catch (Exception e){
                Console.WriteLine("No tickets found with matching criteria");
            }
                break;
            
            case 3:
            try{
                content = await _http.GetStringAsync($"/tickets/{user.UserId}/Denied");
                Console.WriteLine("\n");
                Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                Console.WriteLine("===========================================================");
                foreach(Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(content)){
                    Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }
            } catch (Exception e){
                Console.WriteLine("No tickets with matching criteria found");
            }
                break;
            
            case 4:
            try{
                Console.WriteLine("Please enter category. \n");
                string category = Console.ReadLine()!;
                content = await _http.GetStringAsync($"/tickets/ByContent/{user.UserId}/{category}");
                Console.WriteLine("#  |  Submission Date  |  Username  |  Category  |  Amount | Status");
                Console.WriteLine("===========================================================");
                foreach(Ticket ticket in JsonSerializer.Deserialize<List<Ticket>>(content)){
                Console.WriteLine(ticket.TicketNum + " " + ticket.dateOfSubmission.ToShortDateString() + " " + ticket.Username + " " + ticket.Category + " " + ticket.Amount + " " + ticket.status);
                }
            }catch (Exception e){
                Console.WriteLine("No matching tickets found");
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
using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class SubmitTicket{
    private HttpClient _http;

    public SubmitTicket(IUser user){
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5184/");
        Console.WriteLine("Please enter the amount for your ticket");
        double ticketAmount;
        bool parseSuccess = double.TryParse(Console.ReadLine(), out ticketAmount);
        if (parseSuccess){
            Console.WriteLine("Please enter the category of ticket");
            string? category = Console.ReadLine();
            Ticket ticket = new Ticket(ticketAmount, user.UserId, user.UserName, category);
            PublishTicket(ticket);
        }else{
            Console.WriteLine("Invalid Input. Exiting Operation");
        }
    }
    private async void PublishTicket(Ticket ticket){
            JsonContent newTicket = JsonContent.Create<Ticket>(ticket);
            await _http.PostAsync("newTicket", newTicket);
    }
}
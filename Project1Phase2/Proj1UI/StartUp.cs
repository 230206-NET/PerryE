using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class StartUpScreen{
    private HttpClient _http;
    public StartUpScreen(){
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5148/");
    }
    public void StartAsync(){
        while (true){
            Console.WriteLine("\nHello, and Welcome to the Reimbursement Application");
            Console.WriteLine("Please enter your desired option below\n\n");
            Console.WriteLine("[1] Login to existing account\n\n");
            Console.WriteLine("[2] Register a new account\n\n");
            Console.WriteLine("[0] Exit Application\n");
            string choice = Console.ReadLine()!;
            switch (choice){
                case "1":
                    new LogInScreen();
                    break;
                case "2":
                    new Register();
                    break;
                case "0":
                    return;
            }

        }
    }
}
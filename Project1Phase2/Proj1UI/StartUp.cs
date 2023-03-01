using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class StartUpScreen{
    private HttpClient _http;
    public StartUpScreen(){
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5184/");
    }
    public async Task StartAsync(){
        while (true){
            Console.WriteLine("\nHello, and Welcome to the Reimbursement Application");
            Console.WriteLine("Please enter your desired option below\n\n");
            Console.WriteLine("[1] Login to existing account\n\n");
            Console.WriteLine("[2] Register a new account\n\n");
            Console.WriteLine("[0] Exit Application\n");
            string choice = Console.ReadLine();
            switch (choice){
                case "1":
                    LogInScreen login = new LogInScreen(_http);
                    await login.LogIn();
                    Console.ReadLine();
                    break;
                case "2":
                    await new Register(_http).RegisterScreen();
                    Console.ReadLine();
                    break;
                case "0":
                    return;
            }

        }
    }
}
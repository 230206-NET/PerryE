using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net;
using services;
using System.Threading.Tasks;

using System.Text.Json;

namespace UI;
class LogInScreen{
    private HttpClient _http;
    public LogInScreen(HttpClient http){
        _http = http;
    }
    public async Task LogIn(){
        IUser? logInInfo = await getLoginInfo();
        bool loggedIn = (logInInfo != null);
        if (loggedIn){
            new MainScreen(_http, logInInfo);
        }
        else{
            Console.WriteLine("Incorrect Credentials");
        }
    }
    private async Task<IUser?> getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        var response = await _http.GetStringAsync("users/Login?username={username}&password={password}");
        if(!string.IsNullOrWhiteSpace(response)){
            IUser user = JsonSerializer.Deserialize<IUser>(response);
            return user;
        } else{
            return null;
        }
    }
}
using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net;
using System.Threading.Tasks;

using System.Text.Json;

namespace UI;
class LogInScreen{
    private HttpClient _http;
    public LogInScreen(HttpClient http){
        _http = http;
    }
    public async Task LogIn(){
        IUser logInInfo = await getLoginInfo();
        bool loggedIn = (logInInfo != null);
        if (loggedIn){
            await new MainScreen(_http).MainScreenView(logInInfo);
        }
        else{
            Console.WriteLine("Incorrect Credentials or Error Retrieving Credentials. Please try again");
        }
    }
    private async Task<IUser?> getLoginInfo(){
        Console.WriteLine("Please Enter your username");
        string? username = Console.ReadLine()!.Trim();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine()!.Trim();
        try{
        IUser user = JsonSerializer.Deserialize<IUser>(await _http.GetStringAsync($"users/Login?username={username}&password={password}"));
        return user;
        } catch (Exception e){
            return null;
        }

    }
}
using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Models;
using System.Text.Json;
using System.Text;

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
        return await LoginAsync(username, password);

    }
        public async Task<IUser> LoginAsync(string username, string password)
    {
        // Build the request URI with the username in the query string
        UriBuilder uriBuilder = new UriBuilder("http://localhost:5000/users/Login");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["username"] = username;
        uriBuilder.Query = query.ToString();
        var requestUri = uriBuilder.Uri;

        // Create the request message with the password in the request body
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Content = new StringContent($"\"{password}\"", Encoding.UTF8, "application/json");

        // Send the request and get the response
        var response = await _http.SendAsync(request);

        // Check if the response is successful
        response.EnsureSuccessStatusCode();

        // Read the response body as JSON and deserialize it to a User object
        string userJson = await response.Content.ReadAsStringAsync();
        IUser user = JsonSerializer.Deserialize<IUser>(userJson);

        return user;
    }
}
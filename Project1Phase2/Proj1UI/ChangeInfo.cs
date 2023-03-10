using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class ChangeInfo{
    HttpClient _http;
    public ChangeInfo(HttpClient http){
        _http = http;
    }
    public async Task ChangeInfoScreen(IUser user){
        while (true){
            displayOptions(user);
            int choice;
            bool validInput = int.TryParse(Console.ReadLine(), out choice);
            if (choice == 0) return;
            else{
                await makeChoice(choice, user);
            }
        }

        }

    
    private async Task makeChoice(int selection, IUser user){
                switch (selection){
                    case 1:
                        await ChangeName(user);
                        return;
                    case 2:
                        await ChangeUserName(user);
                        return;
                    case 3:
                        await ChangePhoneNumber(user);
                        return;
                    default:
                        Console.WriteLine("Invalid Input. Please try again");
                        return;
                }

    }
    private void displayOptions(IUser user){
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.UserName);
            Console.WriteLine("Phone Number: " + user.CellNumber);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Username");
            Console.WriteLine("[3] Phone Number");
            Console.WriteLine("[0] Return to home screen");

    }
    private async Task ChangeName(IUser user){
        bool correctInfo = false;
        while(!correctInfo){
            Console.WriteLine("Please write your first name");
            string? firstName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(firstName)){
                Console.WriteLine("Please enter a valid first name");
                firstName = Console.ReadLine()!.Trim();
            }
            Console.WriteLine("Please write you last name");
            string? lastName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(lastName)){
                Console.WriteLine("Please enter a valid last name");
                lastName = Console.ReadLine().Trim();
            }
            Console.WriteLine("So your name is {0} {1}? Press 1 for yes, 2 for no", firstName, lastName);
            int choice;
            bool success = int.TryParse(Console.ReadLine(), out choice);
            if (choice == 1){
                user.FirstName = firstName;
                user.LastName = lastName;
                string name = firstName + " " + lastName;
                await _http.PostAsync("userInfo/name/" + user.UserId + name, null);
                break;
            }
            else{
                continue;
            }
        }


    }
    private async Task ChangeUserName(IUser user){
        Console.WriteLine("Please enter your desired new username");
        string? username = Console.ReadLine();
        while(string.IsNullOrEmpty(username) || await checkForUsername(username) == false){
            Console.WriteLine("IUsername empty or taken. Please try again. Press 0 to exit");
            username = Console.ReadLine();
            if (username == "0"){
                return;
            }
        }
        user.UserName = username;
        await _http.PostAsync("userInfo/username/" + user.UserId + "/" + username, null);
    }
    private async Task ChangePhoneNumber(IUser user){
        Console.WriteLine("Please enter your new Phone Number");
        string? phoneNumber = Console.ReadLine();
        while(string.IsNullOrEmpty(phoneNumber)){
            Console.WriteLine("Please enter a valid phone number");
            phoneNumber = Console.ReadLine();
        }
        user.CellNumber = phoneNumber;
        await _http.PostAsync("userInfo/phone/" + user.UserId + phoneNumber, null);
    }

        private async Task<bool> checkForUsername(string userName){
        string content = await _http.GetStringAsync("/username?username={userName}");
        List<IUser> users = JsonSerializer.Deserialize<List<IUser>>(content);
        return users == null;
    }
}

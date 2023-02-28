using Serilog;
using System.Net.Http;
using System.Net.Http.Json;

using System.Text.Json;

namespace UI;
public class ChangeInfo{
    public ChangeInfo(IUser user){
        while (true){
 /*           displayOptions(user);
            int choice;
            bool validInput = int.TryParse(Console.ReadLine(), out choice);
            if(makeChoice(choice, user) == 0) return;   
        }

        }

    
    private int makeChoice(int selection, IUser user){
                switch (selection){
                    case 1:
                        ChangeName(user);
                        return 1;
                    case 2:
                        ChangeUserName(user);
                        return 1;
                    case 3:
                        ChangePhoneNumber(user);
                        return 1;
                    case  0:
                        return 0;
                    default:
                        Console.WriteLine("Invalid Input. Please try again");
                        return 1;
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
    private void ChangeName(IUser user){
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
                DBAccess.changeUserField("User_Name", user.UserId, name);
                break;
            }
            else{
                continue;
            }
        }


    }
    private void ChangeUserName(IUser user){
        Console.WriteLine("Please enter your desired new username");
        string? username = Console.ReadLine();
        while(string.IsNullOrEmpty(username) || !checkForUsername(username)){
            Console.WriteLine("IUsername empty or taken. Please try again. Press 0 to exit");
            username = Console.ReadLine();
            if (username == "0"){
                return;
            }
        }
        user.UserName = username;
        DBAccess.changeUserField("User_Name", user.UserId, username);
    }
    private void ChangePhoneNumber(IUser user){
        Console.WriteLine("Please enter your new Phone Number");
        string? phoneNumber = Console.ReadLine();
        while(string.IsNullOrEmpty(phoneNumber)){
            Console.WriteLine("Please enter a valid phone number");
            phoneNumber = Console.ReadLine();
        }
        user.CellNumber = phoneNumber;
        DBAccess.changeUserField("Phone_Number", user.UserId, phoneNumber);
    }
        private bool checkForUsername(string userName){
        if (DBAccess.GetUserByUsername(userName) == null){
        return true;
        } else{
            return false;
    }*/
        }
}
}
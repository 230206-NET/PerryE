using Models;
using DataAccess;
namespace UI;
public class ChangeInfo{
    public ChangeInfo(User user){
        while (true){
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.UserName);
            Console.WriteLine("Phone Number: " + user.CellNumber);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Username");
            Console.WriteLine("[3] Phone Number");
            Console.WriteLine("[0] Return to home screen");
            int choice;
            bool validInput = int.TryParse(Console.ReadLine(), out choice);
            if (validInput){
                switch (choice){
                    case 1:
                        ChangeName(user);
                        break;
                    case 2:
                        ChangeUserName(user);
                        break;
                    case 3:
                        ChangePhoneNumber(user);
                        break;
                    case  0:
                        return;
                    default:
                        Console.WriteLine("Invalid Input. Please try again");
                        break;
                }
        }

        }

    }
    private void ChangeName(User user){
        bool correctInfo = false;
        while(!correctInfo){
            Console.WriteLine("Please write your first name");
            string? firstName = Console.ReadLine();
            Console.WriteLine("Please write you last name");
            string? lastName = Console.ReadLine();
            Console.WriteLine("So your name is {0} {1}? Press 1 for yes, 2 for no", firstName, lastName);
            int choice;
            bool success = int.TryParse(Console.ReadLine(), out choice);
            if (choice == 1){
                user.FirstName = firstName;
                user.LastName = lastName;
                string name = firstName + " " + lastName;
                DBAccess.ChangeName(user.UserId, name);
                break;
            }
            else{
                continue;
            }
        }


    }
    private void ChangeUserName(User user){
        Console.WriteLine("Please enter your desired new username");
        string? username = Console.ReadLine();
        while(!checkForUsername(username)){
            Console.WriteLine("Username taken. Please try another username. Enter 0 to cancel");
            username = Console.ReadLine();
            if (username == "0"){
                return;
            }
        }
        user.UserName = username;
        DBAccess.ChangeUserName(user.UserId, username);
    }
    private void ChangePhoneNumber(User user){
        Console.WriteLine("Please enter your new Phone Number");
        string? phoneNumber = Console.ReadLine();
        user.CellNumber = phoneNumber;
        DBAccess.ChangePhoneNumber(user.UserId, phoneNumber);
    }
        private bool checkForUsername(string userName){
        if (DBAccess.GetUserByUsername(userName) == null){
        return true;
        } else{
            return false;
        }
    }
}
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
            if (validInput && choice != 0){
                switch (choice){
                    case 1:
                        ChangeName(user);
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
                DBAccess.ChangeName(user.UserId, firstName, lastName);
                break;
            }
            else{
                continue;
            }
        }


    }
}
using Models;
using services;
using DataAccess;

namespace UI;
class EmployeeTicketView{
    int UserId {set; get;}
    public EmployeeTicketView(int userId){
        this.UserId = userId;
        showTickets();
    }
    private void showTickets(){
        bool returnToHome = false;
        while(!returnToHome){
        Console.WriteLine("Hello. Please choose [1] if you would like to view current tickets. [2] to view past tickets. [0] to return to Main Menu");
        string? option = Console.ReadLine();
        int choice;
        bool madeChoice = int.TryParse(option, out choice);
        switch (choice){
            case 1:
                Console.WriteLine("Fill in with pending tickets view");
                //TicketHelper.displayCurrentEmployeePendingTickets();
                break;
            case 2:
                Console.WriteLine("Fill in with past tickets view");
                //new DecidedTicketsEmployee(UserId);
                break;
            case 0:
                returnToHome = true;
                break;
            default:
                break;
        }
        }
    }
}
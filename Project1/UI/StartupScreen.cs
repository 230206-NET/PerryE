using DataAccess;
using System;
namespace UI;
public class Startup
{
    int option;
    bool validOption = false;
    public Startup(){
        getOptions();
    }
    private void showScreen(){
        Console.WriteLine("\nHello, and Welcome to the Reimbursement Application");
        Console.WriteLine("Please enter your desired option below\n\n");
        Console.WriteLine("[1] Login to existing account\n\n");
        Console.WriteLine("[2] Register a new account\n\n");
        Console.WriteLine("[0] Exit Application\n");
        
    }
    private void makeChoice(int option){
        if (option == 1 || option == 2){
            if (option == 1){
                new LogInScreen();
            } else if (option == 2){
                new Register();
            }
        } else{
            Console.WriteLine("Please Enter a Valid Input");
        }
    }
    private void getOptions(){
        while(true){
            showScreen();
        validOption = int.TryParse(Console.ReadLine()!, out option);
        if (validOption){
            if (option == 0) return;
            makeChoice(option);
            continue;
        }
        else{
            Console.WriteLine("Please enter a valid input");
            continue;
        }
        }
    }
}

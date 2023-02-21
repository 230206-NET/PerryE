using DataAccess;
using System;
namespace UI;
public class Startup
{
    public Startup(){
        int option;
        bool validOption = false;
        while(true){
        Console.WriteLine("Hello, and Welcome to the Reimbursement Application");
        Console.WriteLine("Please enter your desired option below\n\n");
        Console.WriteLine("[1] Login to existing account\n\n");
        Console.WriteLine("[2] Register a new account\n\n");
        Console.WriteLine("[0] Exit Application\n");
        validOption = int.TryParse(Console.ReadLine()!, out option);
        if (validOption && (option == 1 || option == 2 || option == 0)){
            if (option == 1){
                new LogInScreen();
            } else if (option == 2){
                new Register();
            } else{
                break;
            }
        } else{
            Console.WriteLine("Please Enter a Valid Input");
        }
        }
        
        
        
        
    }
}

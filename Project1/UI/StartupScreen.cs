using System;
namespace UI;
public class Startup
{
    public Startup(){
        int option;
        while(true){
        Console.WriteLine("Hello, and Welcome to the Reimbursement Application");
        Console.WriteLine("Please enter your desired option below\n\n");
        Console.WriteLine("[1] Login to existing account\n\n");
        Console.WriteLine("[2] Register a new account\n\n");
        Console.WriteLine("[0] Exit Application\n");
        bool validOption = int.TryParse(Console.ReadLine()!, out option);
        if (validOption && (option == 1 || option == 2 || option == 0)){
            break;
        } else{
            Console.WriteLine("Please Enter a Valid Input");
        }
        }
    }
}

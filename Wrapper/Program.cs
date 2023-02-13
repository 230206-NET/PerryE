using RockPaperScissor;
using firstDotNet;
using Budget;
using HotCold;
using CoinFlipper;
using Hangman;

public class Wrapper{
    public static void Main(string[] args){
        while (true){
        Console.WriteLine("Which application would you like to open? To leave, press 0");
        Console.WriteLine("[1] firstDotNet");
        Console.WriteLine("[2] Budget App");
        Console.WriteLine("[3] Coin Flipper");
        Console.WriteLine("[4] Hot or Cold");
        Console.WriteLine("[5] Hangman");
        Console.WriteLine("[6] Rock Paper Scissors");
        int input;
        bool successfulParse = int.TryParse(Console.ReadLine()!, out input);
        if (successfulParse){
        switch (input){
            case 0:
                Console.WriteLine("Leaving Application");
                break;
            case 1:
                new FirstDotNet();
                break;
            case 2:
                new BudgetApp().run();
                break;
            case 3:
                new Flipper().flipCoin();
                break;
            case 4:
                new HotOrCold().runProgram();
                break;
            case 5:
                new hangman().playGame();
                break;
            case 6:
                new GameLogic().PlayGame();
                break;
            default:
                Console.WriteLine("Invalid Selection: ");
                break;
        }
        if (input == 0){
            break;
        }
    }
    else{
        Console.WriteLine("Invalid input. Please try again");
    }
    }
}
}
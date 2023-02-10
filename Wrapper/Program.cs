using RockPaperScissor;
using firstDotNet;
using Budget;
using HotCold;
using CoinFlipper;
using Hangman;

public class Wrapper{
    public static void Main(string[] args){
        Console.WriteLine("Which application would you like to open?");
        Console.WriteLine("[1] firstDotNet");
        Console.WriteLine("[2] Budget App");
        Console.WriteLine("[3] Coin Flipper");
        Console.WriteLine("[4] Hot or Cold");
        Console.WriteLine("[5] Hangman");
        Console.WriteLine("[6] Rock Paper Scissors");
        int input = int.Parse(Console.ReadLine()!);
        switch (input){
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
    }
}
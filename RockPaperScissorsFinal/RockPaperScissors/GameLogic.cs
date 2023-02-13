using System.Threading;
namespace RockPaperScissor;
public class GameLogic
{
    private string makeChoice(){
        Random r = new Random();
        int numOption = r.Next(0, 3);
        string returnedChoice = "";
        switch (numOption){
            case 0:
            returnedChoice = "Rock";
            break;
            case 1:
            returnedChoice = "Paper";
            break;
            case 2:
            returnedChoice = "Scissors";
            break;
        }
        return returnedChoice;
    }
    private string WinOrLose(string userChoice, string compChoice){
        string winOrLose = "";
        if ((userChoice == "Scissors" && compChoice == "Rock") || (userChoice == "Rock" && compChoice == "Paper") || (userChoice == "Paper" && compChoice == "Scissors")){
            winOrLose = $"Sorry, you lost. You chose {userChoice} and the computer chose {compChoice}";
        } else if (userChoice == compChoice){
            winOrLose = "You and the computer tied. Please try again";
        } else{
            winOrLose = $"Congratulations! You won! You chose {userChoice} and the computer chose {compChoice}";
        }
        return winOrLose;
    }
    public void PlayGame(){
        Console.WriteLine("Let's play a game");
        Console.WriteLine("Please enter one of the following options (default will be Scissors):");
        Console.WriteLine("1: Rock");
        Console.WriteLine("2: Paper");
        Console.WriteLine("3: Scissors");
        string choice = Console.ReadLine()!.ToLower();
        if (choice[0] == 'r' || choice == "1"){
            choice = "Rock";
        } else if (choice[0] == 'p' || choice == "2"){
            choice = "Paper";
        } else{
            choice = "Scissors";
        }
        string compChoice = makeChoice();
        Thread.Sleep(500);
        Console.WriteLine("Rock");
        Thread.Sleep(500);
        Console.WriteLine("Paper");
        Thread.Sleep(500);
        Console.WriteLine("Scissors");
        Thread.Sleep(500);
        Console.WriteLine("Shoot");
        Thread.Sleep(500);
        Console.WriteLine(WinOrLose(choice, compChoice));
    }
}
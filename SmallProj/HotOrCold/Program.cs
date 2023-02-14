// See https://aka.ms/new-console-template for more information
using System;
namespace HotCold
{
	public class HotOrCold
	{
		public void runProgram(){
		Console.WriteLine("The program has started");
		var randNum = new Random();
		int numToGuess = randNum.Next(20);
		bool guessedCorrect = false;
		while (!guessedCorrect)
		{
			Console.WriteLine("Please enter a number to guess:");
			int guessedNum = Int32.Parse(Console.ReadLine()!);
			if (guessedNum > numToGuess)
			{
				Console.WriteLine("You guessed to high. Please try again");
				continue;
			}else if (guessedNum < numToGuess)
			{
				Console.WriteLine("Your guess was too low. Please try again");
			}
			else
			{
				guessedCorrect = true;
			}
		}
			Console.WriteLine("Congratulations. You got the correct number: " + numToGuess);
		}
	}
}

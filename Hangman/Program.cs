﻿using System.Text.RegularExpressions;
namespace Hangman{
    public class hangman{
        public void printOut(){
            Console.WriteLine("Somrthing or other");
        }
        
        public string generateWord(){
            string[] wordList = {"virginia", "california", "florida", "texas", "illinois", "washington", "nevada", "connecticut"};
            Random r = new Random();
            int wordIndex = r.Next(wordList.Length);
            return wordList[wordIndex];
        }
        public void showStatus(int guessNum){
            switch(guessNum){
                case 0:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |  /|\\");
                Console.WriteLine(" |  / \\");
                Console.WriteLine(" |  ");
                Console.WriteLine("___");
                break;
                case 1:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |  /|\\");
                Console.WriteLine(" |  /");
                Console.WriteLine(" |  ");
                Console.WriteLine("___");
                break;
                case 2:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |  /|\\");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("___");
                break;
                case 3:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |  /|");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("___");
                break;
                case 4:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("___");
                break;
                case 5:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |   0");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("___");
                break;
                default:
                Console.WriteLine(" ____");
                Console.WriteLine(" |   |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("___");
                break;
            }
        }
        public void playGame(){
            string wordToGuess = generateWord();
            bool[] letterGuessed = new bool[wordToGuess.Length];
            bool gameWon = false;
            bool gameLost = false;
            Random r = new Random();
            Regex validCharacters = new Regex("^[a-z]$");
            int guessesRemaining = 6;
            char[] incorrectGuesses = new char[10];
            int incGuessesIndex = 0;
            for(int i = 0; i < wordToGuess.Length; i++){
                Console.Write("_");
            }
            while (!gameWon && !gameLost){
                Console.WriteLine("\nPlease enter a letter to guess");
                char guess;
                bool guessFormat = char.TryParse(Console.ReadLine()!.ToLower(), out guess);
                Console.WriteLine("");
                bool wasCorrect = false;
                Match match = validCharacters.Match("" + guess);
                if (match.Success){
                for(int i = 0; i < wordToGuess.Length; i++){
                    if (wordToGuess[i] == guess){
                        letterGuessed[i] = true;
                        wasCorrect = true;
                    }}
                    if (!wasCorrect & !incorrectGuesses.Contains(guess)){
                        guessesRemaining--;
                        incorrectGuesses[incGuessesIndex] = guess;
                        incGuessesIndex++;
                        if(guessesRemaining == 0){
                            Console.WriteLine("You lose");
                            gameLost = true;
                            break;
                        }
                    }
                } else{
                    Console.WriteLine("Please enter a valid character");
                }
                

                Console.WriteLine("\n");
                showStatus(guessesRemaining);
                Console.WriteLine($"Guesses remaining: {guessesRemaining}");
                for (int i = 0; i < wordToGuess.Length; i++){
                    if (letterGuessed[i] == true){
                        Console.Write(wordToGuess[i]);
                    } else{
                        Console.Write("_");
                    }
                }
                if (!letterGuessed.Contains(false)){
                    gameWon = true;
                }

            }
        

            
            if (gameLost){
                Console.WriteLine($"Sorry, the word was {wordToGuess}");
                showStatus(0);
            } else {
                Console.WriteLine($"\nYou won the game. The word was {wordToGuess}");
            }
    
        }

    }
}
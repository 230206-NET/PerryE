using System;
namespace Hangman{
    class Hangman{
        public string generateWord(){
            string[] wordList = {"human", "coding", "object", "simple", "github", "solid", "principle", "random", "program", "class"};
            Random r = new Random();
            int wordIndex = r.Next(10);
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
        public void hangman(){
            string wordToGuess = generateWord();
            bool[] letterGuessed = new bool[wordToGuess.Length];
            bool gameWon = false;
            bool gameLost = false;
            int guessesRemaining = 6;
            for(int i = 0; i < wordToGuess.Length; i++){
                Console.Write("_");
            }
            while (!gameWon && !gameLost){
                Console.WriteLine("Please enter a letter to guess");
                char guess = char.Parse(Console.ReadLine()!);
                Console.WriteLine("");
                bool wasCorrect = false;
                for(int i = 0; i < wordToGuess.Length; i++){
                    if (wordToGuess[i] == guess){
                        letterGuessed[i] = true;
                        wasCorrect = true;
                    }}
                    if (!wasCorrect){
                        guessesRemaining--;
                        if(guessesRemaining == 0){
                            Console.WriteLine("You lose");
                            gameLost = true;
                            break;
                        }
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

        public static void Main(String[] args){
            Console.WriteLine(" ____");
            Console.WriteLine(" |   |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine("___");
            Hangman hangman = new Hangman();
            hangman.hangman();
        }
    }
}

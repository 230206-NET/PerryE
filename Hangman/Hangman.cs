using System.Text.RegularExpressions;
namespace Hangman{
    public class HangMan{
        public void printOut(){
            Console.WriteLine("Something or other");
        }
        
        internal string generateWord(){
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
        internal bool evaluateInputValidity(char input){
            Regex validCharacters = new Regex("^[a-z]$");
            Match match = validCharacters.Match("" + input);
            return match.Success;
        }
        internal bool evaluateInputTrue(char input, string wordToGuess, bool[] lettersGuessed){
            bool guessCorrect = false;
            for (int i = 0; i < wordToGuess.Length; i++){
                if (wordToGuess[i] == input){
                    guessCorrect = true;
                    lettersGuessed[i] = true;
                }
            }
            return guessCorrect;
        }
        internal int evaluateInputIncorrect(int guessesRemaining, int incorrectIndex, char[] incorrectGuesses, char guess){
            guessesRemaining--;
            incorrectGuesses[incorrectIndex] = guess;
            return guessesRemaining;
        }
        internal bool evaluateLoss(int guessesRemaining, string wordToGuess){
            if (guessesRemaining <= 0){
                Console.WriteLine($"You lose, sorry. The word was {wordToGuess}");
                return true;
            }
            return false;
        }
        internal bool evaluateWin(bool[] letterGuessed, string wordToGuess){
            if (!letterGuessed.Contains(false)){
            Console.WriteLine($"Congratulations! You won by guessing the word {wordToGuess}");
            return true;
            }
            else return false;
        }
        internal string evaluateProgress(bool[] lettersGuessed, string wordToGuess){
            string progress = "";
            for (int i = 0; i < lettersGuessed.Length; i++){
                if (lettersGuessed[i] == true){
                    progress+= wordToGuess[i];
                } else{
                    progress+= "_";
                }
            }
            return progress;
        }
        public void playGame(){
            string wordToGuess = generateWord();
            bool[] letterGuessed = new bool[wordToGuess.Length];
            Random r = new Random();
            int guessesRemaining = 6;
            char[] incorrectGuesses = new char[6];
            int incGuessesIndex = 0;
            for(int i = 0; i < wordToGuess.Length; i++){
                Console.Write("_");
            }
            while (true){
                Console.WriteLine("\nPlease enter a letter to guess");
                char guess;
                bool guessFormat = char.TryParse(Console.ReadLine()!.ToLower(), out guess);
                Console.WriteLine("");
                bool wasCorrect = false;
                bool correctFormat = evaluateInputValidity(guess);
                if (correctFormat){
                    wasCorrect = evaluateInputTrue(guess, wordToGuess, letterGuessed);
                    if (!wasCorrect & !incorrectGuesses.Contains(guess)){
                        guessesRemaining = evaluateInputIncorrect(guessesRemaining, incGuessesIndex, incorrectGuesses, guess);
                        incGuessesIndex++;
                        if(evaluateLoss(guessesRemaining, wordToGuess)){
                            break;
                        }
                    }
                } else{
                    Console.WriteLine("Please enter a valid character");
                }
                Console.WriteLine("\n");
                showStatus(guessesRemaining);
                Console.WriteLine($"Guesses remaining: {guessesRemaining}");
                Console.WriteLine(evaluateProgress(letterGuessed, wordToGuess));
                if (evaluateWin(letterGuessed, wordToGuess)){
                    break;
                }

            }
            
    
        }

    }
}
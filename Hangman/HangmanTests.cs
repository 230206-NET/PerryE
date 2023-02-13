using Xunit;
using Hangman;
namespace Tests;

public class HangmanTests{
    [Fact]
    public void TrueMustBeTrue(){
        Assert.True(true);
    }
    [Fact]
    public void generateWordTest(){
        HangMan test = new HangMan();
        string newWord = test.generateWord();
        Assert.False(String.IsNullOrEmpty(newWord));
    }
    [Theory]
    [InlineData('1')]
    [InlineData('!')]
    [InlineData(' ')]
    public void evaluateInputValidityTest(char input){
        HangMan hangman = new HangMan();
        Assert.False(hangman.evaluateInputValidity(input));
    }
    [Theory]
    [InlineData('a', "Texas", true)]
    [InlineData('n', "Vegas", false)]
    public void evaluateInputTrueTest(char input, string wordToGuess, bool expectedOutcome){
        HangMan hangman = new HangMan();
        Assert.Equal(hangman.evaluateInputTrue(input, wordToGuess, new bool[wordToGuess.Length]), expectedOutcome);
    }
    [Theory]
    [InlineData(5, 4)]
    [InlineData(10, 9)]
    [InlineData(1, 0)]
    public void evaluateInputIncorrect(int guessesRemaining, int expectedValue){
        HangMan hangman = new HangMan();
        Assert.Equal(hangman.evaluateInputIncorrect(guessesRemaining, 0, new char[guessesRemaining], 'a'), expectedValue);
    }
    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    [InlineData(-5, true)]
    public void evaluateLossTest(int guessesRemaining, bool expectedValue){
        HangMan hangman = new HangMan();
        string wordToGuess = "Test";
        Assert.Equal(hangman.evaluateLoss(guessesRemaining, wordToGuess), expectedValue);
    }
    [Theory]
    [InlineData(new bool[]{true}, true)]
    [InlineData(new bool[]{false}, false)]
    [InlineData(new bool[]{true, false, true}, false)]
    public void evaluateWinTest(bool[] testArr, bool expectedValue){
        HangMan hangman = new HangMan();
        string wordToGuess = "Testing";
        Assert.Equal(hangman.evaluateWin(testArr, wordToGuess), expectedValue);
    }
}
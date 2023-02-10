using System;
using System.Text.RegularExpressions;
namespace Hangman{
    class Game{
        public static void Main(String[] args){
            Additional Hangman = new Additional();
            Hangman.showStatus(6);
            Hangman.hangman();
        }
    }
}

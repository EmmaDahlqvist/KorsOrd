using System;

namespace KorsOrd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //objekt
            Letters lettersClass = new Letters();
            PrintToConsole print = new PrintToConsole();
            Correction correction = new Correction();
            Game game = new Game();
            Hints hints = new Hints();

            int level = 1;
            bool playAgain = false;

            do //spela spelet först, fråga sedan om de vill spela igen
            {
                string[] letters = lettersClass.LettersList(level); //rätt bokstäver
                string[] guessedLetters = hints.GuessedLettersList(level); //gissade bokstäver

                game.PlayGame(guessedLetters, letters, level); //starta spel

                //kolla antal rätt
                int correctCount = correction.CorrectAnswerCount(guessedLetters, letters);
                int wrongCount = letters.Length - correctCount;

                int levelUp = game.LevelUp(wrongCount);
                level += levelUp;
                playAgain = game.PlayAgain(level, levelUp, wrongCount);

            } while (playAgain);

            //spelet är över
            print.PrintSlow("\nGoodbye...", 100, ConsoleColor.DarkRed);
        }
    }
}
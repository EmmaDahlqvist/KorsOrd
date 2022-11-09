using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace KorsOrd
{
    internal class Game
    {
        Letters lettersClass = new Letters();
        Hints hints = new Hints();
        Guesses guess = new Guesses();
        PrintToConsole print = new PrintToConsole();

        //starta igång spelet
        public void PlayGame(string[] guessedLetters, string[] letters, int level)
        {
            //tills att alla platser är fyllda med bokstäver
            while (lettersClass.getIndexes(guessedLetters).Count > 0)
            {
                print.WriteBoard(guessedLetters, letters, false); //skriv ut spelplan
                hints.GiveHints(level); //hints
                guess.Guess(guessedLetters); //hantera gissningar
            }

            //spel slut -> rätta
            print.WriteBoard(guessedLetters, letters, true);
        }

        public int LevelUp(int wrongCount)
        {
            int levels = 0;

            if (wrongCount == 0) //alla rätt -> ny level
            {
                levels = 1;
            }

            return levels;
        }

        public bool PlayAgain(int level, int levelUp, int wrongCount)
        {
            bool playAgain = false;
            if(levelUp == 1) //vann omgången
            {
                //spela igen alternativ
                if (lettersClass.LettersList(level) != null) 
                {
                    print.Print(ConsoleColor.White, -1, -1, "You won this level! Do you want to play again? Type yes or no");
                }
                else //max level
                {
                    print.Print(ConsoleColor.Green, -1, -1, "Good job you finished the game!");
                    return false;
                }
            }
            else //några fel
            {
                print.Print(ConsoleColor.White, -1, -1, "You got " + wrongCount + " answers wrong. Do you want to play again? Type yes or no");
            }

            string yesOrNo = Console.ReadLine();
            if (yesOrNo.ToLower() == "yes")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }
            return playAgain;
        }
    }
}

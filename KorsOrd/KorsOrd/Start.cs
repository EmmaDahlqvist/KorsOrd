using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class Start
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
                hints.GiveHints(level);
                guess.Guess(guessedLetters); //hantera gissningar
            }

            //rätta
            print.WriteBoard(guessedLetters, letters, true);
        }
    }
}

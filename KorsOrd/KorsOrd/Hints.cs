using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class Hints
    {
        PrintToConsole print = new PrintToConsole();
        Letters lettersClass = new Letters();

        public string[] GuessedLettersList(int level)
        {
            //de gissade bokstäverna
            string[] guessedLetters = lettersClass.GuessedLetterIndexes();

            //ge hints på random bokstäver
            string[] letters = lettersClass.LettersList(level);
            Random rnd = new Random();
            int amountOfHints = rnd.Next(3, 7);

            for (int i = 0; i < amountOfHints; i++)
            {
                //index som ska bytas ut
                int hintIndex = rnd.Next(letters.Length);

                //ifall indexet bara är ett mellanrum
                while (true)
                {
                    if (letters[hintIndex] == " ")
                    {
                        hintIndex = rnd.Next(letters.Length);
                    }
                    else
                    {
                        //det är en bokstav
                        break;
                    }
                }
                guessedLetters[hintIndex] = letters[hintIndex];
            }
            return guessedLetters;
        }
        public void GiveHints(int level)
        {
            if (level == 1)
            {
                print.Print(ConsoleColor.DarkYellow, -1, -1, "-----------HINTS----------- \n" +
                    "The first word is something you can do with material\n" +
                    "The second word is another word for forbid \n" +
                    "The third word is a facial body part \n" +
                    "The last word is a union\n" +
                    "---------------------------");
            }
            else if (level == 2)
            {
                print.Print(ConsoleColor.DarkYellow, -1, -1, "-----------HINTS----------- \n" +
                    "The first word is a game\n" +
                    "The second word is another word for brother\n" +
                    "The third word is a synonym of exclude \n" +
                    "The last word is an antonym to from\n" +
                    "---------------------------");
            }
            else if (level == 3)
            {
                print.Print(ConsoleColor.DarkYellow, -1, -1, "-----------HINTS----------- \n" +
                    "The first word is a nice weather condition\n" +
                    "The second word is a type of water\n" +
                    "The third word is a synonym to as well\n" +
                    "The last word is a short for overpowered\n" +
                    "---------------------------");
            }
            else if (level == 4)
            {
                print.Print(ConsoleColor.DarkYellow, -1, -1, "-----------HINTS----------- \n" +
                    "The first word is an animal\n" +
                    "The second word is meat on a sandwich\n" +
                    "The third word is usually read at a restaurant \n" +
                    "The last word is a short for the united states\n" +
                    "---------------------------");
            }
        }
    }
}

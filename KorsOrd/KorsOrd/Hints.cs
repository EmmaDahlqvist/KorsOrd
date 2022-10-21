﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            int amountOfHints = rnd.Next(4, 7);
            List<int> confirmedHintIndexes = new List<int>(); 

            for (int i = 0; i < amountOfHints; i++)
            {
                //index som ska bytas ut
                int hintIndex = rnd.Next(letters.Length);
                //skapa korrekta hints
                while (incorrectHint(confirmedHintIndexes, hintIndex, guessedLetters[hintIndex]))
                {
                    hintIndex = rnd.Next(letters.Length);
                }
                confirmedHintIndexes.Add(hintIndex);
            }

            //byt ut till index till hint bokstav
            for (int i = 0; i < confirmedHintIndexes.Count; i++)
            {
                guessedLetters[confirmedHintIndexes[i]] = letters[confirmedHintIndexes[i]];
            }
            return guessedLetters;
        }

        //finn inkorrekta hints
        public bool incorrectHint(List<int> confirmedIndexes, int index, string letter)
        {
            //mellanrum
            if (letter == " ")
            {
                return true;
            }

            //finns redan
            if (confirmedIndexes.Contains(index))
            {
                return true;
            }

            //bredvid en annan bokstav
            for (int i = 0; i < confirmedIndexes.Count; i++)
            {
                if(index + 2 == confirmedIndexes[i] || index - 2 == confirmedIndexes[i])
                {
                    return true;
                }
                if(index + 1 == confirmedIndexes[i] || index - 1 == confirmedIndexes[i])
                {
                    Console.WriteLine(index +  " " + confirmedIndexes[i]);
                    return true;
                }
            }

            return false;
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

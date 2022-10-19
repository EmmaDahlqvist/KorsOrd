using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class Guesses
    {
        TryInt tryInt = new TryInt();
        PrintToConsole print = new PrintToConsole();
        Letters letters = new Letters();

        //ta in gissning lägg till i listan
        public void Guess(string[] guessedLetters)
        {
            int index = ChosenIndex(guessedLetters);
            string letter = GuessedLetter(guessedLetters);

            //lägg till bokstav i guessedLetters
            bool indexIsCorrect = false;
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                if (guessedLetters[i] == index.ToString()) //replaca index
                {
                    guessedLetters[i] = letter;
                    indexIsCorrect = true;
                    break;
                }

                //breaka loopen för att undvika onödig loop
                if (indexIsCorrect)
                {
                    break;
                }
            }
        }

        public int ChosenIndex(string[] guessedLetters)
        {
            ////välj index
            print.Print(ConsoleColor.White, -1, -1, "Choose an index to replace with a letter: ");
            int index = -1;

            bool correctIndex = false;
            while (!correctIndex) //tills att gissad index är giltlig
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string stringIndex = Console.ReadLine();
                if (tryInt.TestStringIsInt(stringIndex)) //det är en int
                {
                    index = int.Parse(stringIndex); //konvertera

                    //ifall index finns/finns kvar i listan
                    if (letters.getIndexes(guessedLetters).Contains(index))
                    {
                        correctIndex = true;
                    }
                    else
                    {
                        print.Print(ConsoleColor.DarkRed, -1, -1, "Index was out of bound");
                    }
                }

                else
                {
                    print.Print(ConsoleColor.DarkRed, -1, -1, "Index has to be an int!");
                }
            }

            return index;
        }

        public string GuessedLetter(string[] guessedLetters)
        {
            //se till att det endast är en BOKSTAV (konvertera string till char)
            string letter = null;
            bool correctGuess = false;
            while (!correctGuess)
            {
                //välj bokstav
                print.Print(ConsoleColor.White, -1, -1, "Guess the letter: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                letter = Console.ReadLine().ToUpper();

                //testa bokstav
                if (tryInt.TestStringIsInt(letter))
                {
                    //det är en int
                    print.Print(ConsoleColor.DarkRed, -1, -1, "It has to be a letter!");
                }
                else
                {
                    //testa så det endast är en bokstav
                    if (letter.Length == 1)
                    {
                        correctGuess = true;
                    }
                    else
                    {
                        print.Print(ConsoleColor.DarkRed, -1, -1, "Only one letter please!");
                    }
                }
            }

            return letter;
        }

    }
}

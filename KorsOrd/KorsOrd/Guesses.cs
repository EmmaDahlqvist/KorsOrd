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
            int index = ChosenIndex(guessedLetters); //vald index
            string letter = GuessedLetter(guessedLetters); //vald bokstav

            //lägg till bokstav i guessedLetters
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                //hitta platsen
                if (guessedLetters[i] == index.ToString()) 
                {
                    //replaca index till vald bokstav
                    guessedLetters[i] = letter;
                    break;
                }
            }
        }

        //ta in valt index
        public int ChosenIndex(string[] guessedLetters)
        {
            print.Print(ConsoleColor.White, -1, -1, "Choose an index to replace with a letter: ");
            int index = -1;

            while (true) //tills att gissad index är giltlig
            {
                //välj index
                Console.ForegroundColor = ConsoleColor.Red;
                string stringIndex = Console.ReadLine();
                if (tryInt.TestStringIsInt(stringIndex)) //det är en int
                {
                    index = int.Parse(stringIndex); //konvertera

                    if (letters.getIndexes(guessedLetters).Contains(index)) //ifall index finns kvar i listan
                    {
                        break;
                    }
                    else //finns ej kvar
                    {
                        print.Print(ConsoleColor.DarkRed, -1, -1, "Index was out of bound");
                    }
                }
                else //det är inte en int
                {
                    print.Print(ConsoleColor.DarkRed, -1, -1, "Index has to be an int!");
                }
            }
            return index;
        }

        //ta in gissad bokstav
        public string GuessedLetter(string[] guessedLetters)
        {
            string letter = null;
            print.Print(ConsoleColor.White, -1, -1, "Guess the letter: ");

            //se till är det endast en BOKSTAV 
            while (true)
            {
                //input
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
                        break;
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

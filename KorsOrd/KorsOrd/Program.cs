using System;
using System.Collections.Generic;

namespace KorsOrd
{
    class Program
    {
        //notes:
        /*Ska man kunna ändra sitt val?
         Man kan nu skriva siffror istället för bokstäver i input
         Ge hints
         Kolla om det är rätt ord
         */
        static void Main(string[] args)
        {
            //ordens alla bokstäver
            string[][] letters = new string[][] {
            new string[] { "S", "O", "L", "E", "N" },
            new string[] {"A"},
            new string[] {"L", "A", "N"},
            new string[]{ "D", "U"} };

            string[][] guessedLetters = new string[][] {
            new string[] { "1", "2", "3", "4", "5" },
            new string[] {"6"},
            new string[] {"7", "8", "9"},
            new string[] {"10", "11"} };

            //10 gissningar
            for(int i = 0; i < 10; i++)
            {
                WriteBoard(guessedLetters);
                Guess(guessedLetters);
            }
        }

        //hantera gissningar
        static void Guess(string[][] guessedLetters)
        {
            //välj index
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose an index to guess:");
            int index = -1;

            bool correctIndex = false;
            while(!correctIndex)
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if (getIndexes(guessedLetters).Contains(index)) //ifall index finns i listorna
                    {
                        correctIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("Index was out of bound");
                    }
                }
                catch (Exception e)
                {
                    correctIndex = false;
                    Console.WriteLine("Index has to be an int!");
                }
            }


            //se till att det endast är en bokstav
            string letter = null;
            bool oneLetter = false;
            while (!oneLetter)
            {
                //välj bokstav
                Console.WriteLine("Guess the letter:");
                letter = Console.ReadLine();

                if (letter.Length == 1)
                {
                    oneLetter = true;
                } else
                {
                    Console.WriteLine("Only one letter please!");
                }
            }

            bool indexIsCorrect = false;
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                for (int j = 0; j < guessedLetters[i].Length; j++)
                {
                    if (guessedLetters[i][j] == index.ToString()) //replaca index
                    {
                        guessedLetters[i][j] = letter;
                        indexIsCorrect = true;
                        break;
                    }
                }
                //breaka loopen för att undvika onödig loop
                if (indexIsCorrect)
                {
                    break;
                }

            }
        }

        //få alla indexes som inte är utbytta
        static List<int> getIndexes(string[][] guessedLetters)
        {
            List<int> indexes = new List<int>();

            for(int i = 0; i < guessedLetters.Length; i++)
            {
                for(int j = 0; j < guessedLetters[i].Length; j++)
                {
                    try //kolla vilka element som fortfarande består av siffror
                    {
                        //adda till listan av indexes ifall det är möjligt
                        indexes.Add(int.Parse(guessedLetters[i][j]));
                    } catch(Exception e) { }
                }
            }

            return indexes;
        }

        //skriv ut spelet
        static void WriteBoard(string[][] letters)
        {
            Console.Clear();
            for(int i = 0; i < letters.Length; i++) //loopa genom två dimisionel array
            {
                for(int j = 0; j < letters[i].Length; j++)
                {
                    ConsoleColor color = ConsoleColor.Red;

                    try
                    {
                        //ifall det går att omvandla från string till int 
                        int.Parse(letters[i][j]);
                        color = ConsoleColor.Red;


                    } catch(Exception e)
                    {
                        //skriv ut gissningar i blå färg
                        color = ConsoleColor.Blue;
                    }


                    if (i == 0) //för "solen"
                    {
                        Print(color, j, i, letters[i][j].ToString());
                    }
                    if(i == 1) //för "sal"
                    {
                        Print(color, j, i, letters[i][j].ToString());
                    }
                    if(i == 2) //för "land"
                    {
                        Print(color, j, i, letters[i][j].ToString());
                    }
                    if(i == 3) //för "du"
                    {
                        Print(color, i, j+2, letters[i][j].ToString());
                    }

                }
            }
        }

        //printa på konsoll med koordinater och färg
        static void Print(ConsoleColor color, int x, int y, string text)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }
    }
}

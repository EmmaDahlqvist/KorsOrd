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
            new string[] {"S", "O", "L", "E", "N" },
            new string[] {"A"},
            new string[] {"L", "A", "N"},
            new string[] { "D", "U"} };

            string[][] guessedLetters = new string[][] {
            new string[] {"1", "2", "3", "4", "5" },
            new string[] {"6"},
            new string[] {"7", "8", "9"},
            new string[] {"10", "11"} };

            //tills att alla platser är fyllda med bokstäver
            while(getIndexes(guessedLetters).Count > 0)
            {
                WriteBoard(guessedLetters, letters, false);
                Guess(guessedLetters);
            }

            //kolla om bokstäverna stämmer
            WriteBoard(guessedLetters, letters, true);

        }

        //grön färg rätt, röd fel
        static ConsoleColor RightAnswer(string guessedLetter, string letter)
        {
            if(guessedLetter == letter)
            {
                return ConsoleColor.Green;
            } else
            {
                return ConsoleColor.DarkRed;
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
                string stringIndex = Console.ReadLine();
                if (TestStringIsInt(stringIndex)) //det är en int
                {
                    index = int.Parse(stringIndex);

                    //ifall index finns kvar (ej gissat eller utanför listan)
                    if (getIndexes(guessedLetters).Contains(index))
                    {
                        correctIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("Index was out of bound");
                    }

                } else
                {
                    correctIndex = false;
                    Console.WriteLine("Index has to be an int!");
                }

            }

            //se till att det endast är en bokstav
            string letter = null;
            bool correctGuess = false;
            while (!correctGuess)
            {
                //välj bokstav
                Console.WriteLine("Guess the letter:");
                letter = Console.ReadLine().ToUpper();
                if (TestStringIsInt(letter))
                {
                    //det är en int
                    Console.WriteLine("It has to be a letter!");
                } else
                {
                    //testa så det endast är en bokstav
                    if (letter.Length == 1)
                    {
                        correctGuess = true;
                    }
                    else
                    {
                        Console.WriteLine("Only one letter please!");
                    }
                }
            }

            //lägg till bokstav i guessedLetters
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

        static bool TestStringIsInt(string input)
        {
            try
            {
                int.Parse(input);

                //string går att replaca med en int
                return true;
            } catch(Exception e)
            {
                //string går inte att replaca -> det är bokstäver/tecken t.ex
                return false;
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
        static void WriteBoard(string[][] guessedLetters, string[][] letters, bool gameOver)
        {
            Console.Clear();
            for(int i = 0; i < guessedLetters.Length; i++) //loopa genom två dimisionel array
            {

                for(int j = 0; j < guessedLetters[i].Length; j++)
                {
                    ConsoleColor color = ConsoleColor.Red;

                    //spelet är inte över, blå är de gissade bokstäverna röd är ogissade
                    if(gameOver == false)
                    {
                        try
                        {
                            //ifall det går att omvandla från string till int 
                            int.Parse(guessedLetters[i][j]);
                            color = ConsoleColor.Red;


                        }
                        catch (Exception e)
                        {
                            //skriv ut gissningar i blå färg
                            color = ConsoleColor.Blue;
                        }
                        //spelet är över, grön är rätt röd är fel
                    } else if (gameOver)
                    {
                        color = RightAnswer(guessedLetters[i][j], letters[i][j]);
                    }


                    if (i == 0) //för "solen"
                    {
                        Print(color, j, i, guessedLetters[i][j].ToString());
                    }
                    if(i == 1) //för "sal"
                    {
                        Print(color, j, i, guessedLetters[i][j].ToString());
                    }
                    if(i == 2) //för "land"
                    {
                        Print(color, j, i, guessedLetters[i][j].ToString());
                    }
                    if(i == 3) //för "du"
                    {
                        Print(color, i, j+2, guessedLetters[i][j].ToString());
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

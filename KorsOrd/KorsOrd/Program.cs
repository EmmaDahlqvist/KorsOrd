using System;
using System.Collections.Generic;
using System.Threading;

namespace KorsOrd
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false; //default false
            do
            {
                PlayGame(); //spela spelet

                //spel avklarat
                Print(ConsoleColor.White, -1, -1, "Do you want to play again? Type yes or no");
                string yesOrNo = Console.ReadLine();

                if (yesOrNo.ToLower() == "yes")
                {
                    playAgain = true;
                } else
                {
                    playAgain = false;
                }

            } while (playAgain);

            //spelet är över
            PrintSlow("\nGoodbye...", 100, ConsoleColor.DarkRed);
        }

        static void PlayGame()
        {
            //ordens alla bokstäver
            string[][] letters = new string[][] {
            new string[] {"B", " ", "U", " ", "I", " ", "L", " ", "D" },
            new string[] {"A"},
            new string[] {"N", " ", "O", " ", "S"},
            new string[] { "E", "U"} };

            //de gissade bokstäverna + hints
            string[][] guessedLetters = new string[][] {
            new string[] {"B", " ", "2", " ", "I", " ", "4", " ", "D" },
            new string[] {"6"},
            new string[] {"N", " ", "O", " ", "9"},
            new string[] {"10", "U"} };

            //tills att alla platser är fyllda med bokstäver
            while (getIndexes(guessedLetters).Count > 0)
            {
                WriteBoard(guessedLetters, letters, false);
                Console.ForegroundColor = ConsoleColor.Red;
                Print(ConsoleColor.White, -1, -1, "Hint: word one is a verb" +
                    "\nWord two is another word for kick out\nWord three is a body part" +
                    "\nWord four is a union");
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
            Print(ConsoleColor.White, -1, -1, "Choose an index to replace with a letter: ");
            int index = -1;

            bool correctIndex = false;
            while(!correctIndex) //tills att gissad index är giltlig
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string stringIndex = Console.ReadLine();
                if (TestStringIsInt(stringIndex)) //det är en int
                {
                    index = int.Parse(stringIndex); //konvertera

                    //ifall index finns kvar (ej gissat eller utanför listan)
                    if (getIndexes(guessedLetters).Contains(index))
                    {
                        correctIndex = true;
                    }
                    else
                    {
                        Print(ConsoleColor.DarkRed, -1, -1, "Index was out of bound");
                    }

                } else
                {
                    correctIndex = false;
                    Print(ConsoleColor.DarkRed, -1, -1, "Index has to be an int!");
                }

            }

            //se till att det endast är en bokstav
            string letter = null;
            bool correctGuess = false;
            while (!correctGuess)
            {
                //välj bokstav
                Print(ConsoleColor.White, -1, -1, "Guess the letter: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                letter = Console.ReadLine().ToUpper();
                if (TestStringIsInt(letter))
                {
                    //det är en int
                    Print(ConsoleColor.DarkRed, -1, -1, "It has to be a letter!");
                } else
                {
                    //testa så det endast är en bokstav
                    if (letter.Length == 1)
                    {
                        correctGuess = true;
                    }
                    else
                    {
                        Print(ConsoleColor.DarkRed, -1, -1, "Only one letter please!");
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
                        Print(color, i+3, j+2, guessedLetters[i][j].ToString());
                    }
                }
            }
        }

        //printa på konsoll med koordinater och färg
        static void Print(ConsoleColor color, int x, int y, string text)
        {
            Console.ForegroundColor = color;
            if(x == -1 && y == -1){ //x och y är inte bestämt
                Console.WriteLine(text);
            } else
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(text);
            }
        }

        //printa en bokstav i taget med delay
        static void PrintSlow(string text, int delay, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            char[] letters = text.ToCharArray(); //string till char array
            for(int i = 0; i < letters.Length; i++) //loopa bokstäver
            {
                Console.Write(letters[i]);
                Thread.Sleep(delay);
            }
        }
    }
}

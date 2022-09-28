using System.Collections.Generic;
using System.Threading;
using System;

namespace KorsOrd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false; //default false
            do //spela spelet först, fråga sedan om de vill spela igen
            {
                PlayGame();

                //runda avklarad
                Print(ConsoleColor.White, -1, -1, "Do you want to play again? Type yes or no");
                string yesOrNo = Console.ReadLine();

                if (yesOrNo.ToLower() == "yes")
                {
                    playAgain = true;
                }
                else
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
            string[] letters = new string[] {
            "B", " ", "U", " ", "I", " ", "L", " ", "D",
            "A",
            "N", " ", "O", " ", "S", " ", "E",
            "U"};

            //de gissade bokstäverna + hints
            string[] guessedLetters = new string[] {
            "B", " ", "2", " ", "I", " ", "4", " ", "D",
            "6",
            "N", " ", "8", " ", "9"," ", "E",
            "11"};

            //tills att alla platser är fyllda med bokstäver
            while (getIndexes(guessedLetters).Count > 0)
            {
                WriteBoard(guessedLetters, letters, false);
                Print(ConsoleColor.White, -1, -1, "Hint: word one is a verb" +
                    "\nWord two is another word for kick out\nWord three is a body part" +
                    "\nWord four is a union");
                Guess(guessedLetters); //hantera gissningar
            }

            //rätta
            WriteBoard(guessedLetters, letters, true);
        }

        //grön färg rätt, röd fel
        static ConsoleColor RightAnswer(string guessedLetter, string letter)
        {
            if (guessedLetter == letter)
            {
                return ConsoleColor.Green;
            }
            else
            {
                return ConsoleColor.DarkRed;
            }
        }

        //ta in gissning lägg till i listan
        static void Guess(string[] guessedLetters)
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

        static int ChosenIndex(string[] guessedLetters)
        {
            ////välj index
            Print(ConsoleColor.White, -1, -1, "Choose an index to replace with a letter: ");
            int index = -1;

            bool correctIndex = false;
            while (!correctIndex) //tills att gissad index är giltlig
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string stringIndex = Console.ReadLine();
                if (TestStringIsInt(stringIndex)) //det är en int
                {
                    index = int.Parse(stringIndex); //konvertera

                    //ifall index finns/finns kvar i listan
                    if (getIndexes(guessedLetters).Contains(index))
                    {
                        correctIndex = true;
                    }
                    else
                    {
                        Print(ConsoleColor.DarkRed, -1, -1, "Index was out of bound");
                    }
                }

                else
                {
                    Print(ConsoleColor.DarkRed, -1, -1, "Index has to be an int!");
                }
            }

            return index;
        }

        static string GuessedLetter(string[] guessedLetters)
        {
            //se till att det endast är en BOKSTAV (konvertera string till char)
            string letter = null;
            bool correctGuess = false;
            while (!correctGuess)
            {
                //välj bokstav
                Print(ConsoleColor.White, -1, -1, "Guess the letter: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                letter = Console.ReadLine().ToUpper();

                //testa bokstav
                if (TestStringIsInt(letter))
                {
                    //det är en int
                    Print(ConsoleColor.DarkRed, -1, -1, "It has to be a letter!");
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
                        Print(ConsoleColor.DarkRed, -1, -1, "Only one letter please!");
                    }
                }
            }

            return letter;
        }

        static bool TestStringIsInt(string input)
        {
            try
            {
                int.Parse(input);

                //string går att replaca med en int
                return true;
            }
            catch (Exception e)
            {
                //string går inte att replaca -> det är bokstäver/tecken t.ex
                return false;
            }
        }

        //få alla indexes som är kvar i listan
        static List<int> getIndexes(string[] guessedLetters)
        {
            List<int> indexes = new List<int>(); //dynamisk temp lista

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                if (TestStringIsInt(guessedLetters[i]))
                {
                    indexes.Add(int.Parse(guessedLetters[i]));
                }
            }
            return indexes;
        }

        //skriv ut spelet
        static void WriteBoard(string[] guessedLetters, string[] letters, bool gameOver)
        {
            int tempPositionX = 0;
            int tempPositionY = 0;

            Console.Clear();
            for (int i = 0; i < guessedLetters.Length; i++) //loopa genom array
            {
                string guess = guessedLetters[i];
                string correct = letters[i];
                ConsoleColor color = ConsoleColor.Red; //default 

                //spelet är inte över, blå är de gissade bokstäverna röd är ogissade
                if (gameOver == false)
                {

                    if (TestStringIsInt(guess)) //ints
                    {
                        color = ConsoleColor.Red;
                    }
                    else //bokstäver
                    {
                        color = ConsoleColor.Blue;
                    }

                    //spelet är över, grön är rätt röd är fel
                }
                else if (gameOver)
                {
                    color = RightAnswer(guess, correct);
                }

                //skriv ut orden
                if (i <= 8) //för "Build"
                {
                    Print(color, i, 0, guess);
                }
                else if (i <= 9) //för " a"
                {
                    tempPositionY = 1;
                    Print(color, 0, tempPositionY, guess);
                    tempPositionY++;
                }
                else if (i <= 16) //för "nose"
                {
                    Print(color, tempPositionX, tempPositionY, guess);
                    tempPositionX++;
                }
                else //för " u"
                {
                    tempPositionX--;
                    tempPositionY++;
                    Print(color, tempPositionX, tempPositionY, guess);
                }
            }
        }

        //printa på konsoll med koordinater och färg
        static void Print(ConsoleColor color, int x, int y, string text)
        {
            Console.ForegroundColor = color;
            if (x == -1 && y == -1)
            { //x och y är inte bestämt
                Console.WriteLine(text);
            }
            else
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
            for (int i = 0; i < letters.Length; i++) //loopa bokstäver
            {
                Console.Write(letters[i]);
                Thread.Sleep(delay);
            }
        }
    }
}
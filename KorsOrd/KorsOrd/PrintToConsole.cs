using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace KorsOrd
{
    internal class PrintToConsole
    {
        TryInt tryInt = new TryInt();
        Correction correction = new Correction();

        //skriv ut spelet
        public void WriteBoard(string[] guessedLetters, string[] letters, bool gameOver)
        {
            int tempPositionX = 0;
            int tempPositionY = 0;
            //Console.Clear();

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                string guess = guessedLetters[i];
                string correct = letters[i];
                ConsoleColor color = BoardColor(guess, correct, gameOver);

                //skriv ut orden
                if (i <= 8) //för ord 1
                {
                    Print(color, i, 0, guess);
                }
                else if (i <= 9) //för ord 2 vertikal
                {
                    tempPositionY = 1;
                    Print(color, 0, tempPositionY, guess);
                    tempPositionY++;
                }
                else if (i <= 16) //för ord 2 horisontell
                {
                    Print(color, tempPositionX, tempPositionY, guess);
                    tempPositionX++;
                }
                else //för ord 4 vertikal
                {
                    tempPositionX--;
                    tempPositionY++;
                    Print(color, tempPositionX, tempPositionY, guess);
                }
            }
        }

        public ConsoleColor BoardColor(string guess, string correct, bool gameOver)
        {
            if (gameOver == false)
            {
                if (tryInt.TestStringIsInt(guess))
                {
                    return ConsoleColor.Red;
                }
                else
                {
                    return ConsoleColor.Blue;
                }
            }
            else if (gameOver)
            {
                if (correction.RightAnswer(guess, correct))
                {
                    return ConsoleColor.Green;
                }
                else
                {
                    return ConsoleColor.DarkRed;
                }
            }
            return ConsoleColor.Red; //default
        }

        //printa på konsoll med koordinater och färg
        public void Print(ConsoleColor color, int x, int y, string text)
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
        public void PrintSlow(string text, int delay, ConsoleColor color)
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

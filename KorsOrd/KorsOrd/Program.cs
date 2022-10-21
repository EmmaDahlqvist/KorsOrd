using System.Collections.Generic;
using System.Threading;
using System;

namespace KorsOrd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //objekt
            Letters lettersClass = new Letters();
            PrintToConsole print = new PrintToConsole();
            Program program = new Program();
            Correction correction = new Correction();
            Start start = new Start();
            Hints hints = new Hints();

            int level = 1;
            bool playAgain = false;

            do //spela spelet först, fråga sedan om de vill spela igen
            {
                string[] letters = lettersClass.LettersList(level); //rätt bokstäver
                string[] guessedLetters = hints.GuessedLettersList(level); //gissade bokstäver

                start.PlayGame(guessedLetters, letters, level); //starta spel

                //kolla antal rätt
                int correctCount = correction.CorrectAnswerCount(guessedLetters, letters);
                int wrongCount = letters.Length - correctCount;
                if (wrongCount == 0) //alla rätt -> ny level
                {
                    level++;
                    if(letters != null)
                    {
                        print.Print(ConsoleColor.White, -1, -1, "You won this level! Do you want to play again? Type yes or no");
                    }
                    else
                    {
                        print.Print(ConsoleColor.Green, -1, -1, "You finished the game. Press enter to end it!");
                    }
                }
                else //några fel
                {
                    print.Print(ConsoleColor.White, -1, -1, "You got " + wrongCount + " answers wrong. Do you want to play again? Type yes or no");
                }

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
            print.PrintSlow("\nGoodbye...", 100, ConsoleColor.DarkRed);
        }
    }
}
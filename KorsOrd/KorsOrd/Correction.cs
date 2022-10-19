using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class Correction
    {
        //rätt eller fel bokstav
        public bool RightAnswer(string guessedLetter, string letter)
        {
            if (guessedLetter == letter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //kolla efter antalet rätt
        public int CorrectAnswerCount(string[] guessedLetters, string[] letters)
        {
            int correctCount = 0;
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                //det är inte en int, det är en bokstav
                if (RightAnswer(guessedLetters[i], letters[i]))
                {
                    correctCount++;
                }
            }
            return correctCount;
        }
    }
}

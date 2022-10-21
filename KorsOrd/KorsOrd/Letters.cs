using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class Letters
    {
        TryInt tryInt = new TryInt();
        public string[] LettersList(int level)
        {
            if (level == 1)
            {
                return new string[] { 
                "B", " ", "U", " ", "I", " ", "L", " ", "D",
                "A",
                "N", " ", "O", " ", "S", " ", "E",
                                              "U"};
            }
            else if (level == 2)
            {
                return new string[] {
                "B", " ", "I", " ", "N", " ", "G", " ", "O",
                "R",
                "O", " ", "M", " ", "I", " ", "T",
                                              "O"};
            }
            else if (level == 3)
            {
                return new string[] {
                "S", " ", "U", " ", "N", " ", "N", " ", "Y",
                "E",
                "A", " ", "L", " ", "S", " ", "O",
                                              "P"};
            }
            else if (level == 4)
            {
                return new string[] {
                "H", " ", "O", " ", "R", " ", "S", " ", "E",
                "A",
                "M", " ", "E", " ", "N", " ", "U",
                                              "S"};
            }
            return null; //level finns ej
        }

        public string[] GuessedLetterIndexes()
        {
            //de gissade bokstäverna
            string[] guessedLetters = new string[] {
            "1", " ", "2", " ", "3", " ", "4", " ", "5",
            "6",
            "7", " ", "8", " ", "9"," ", "10",
            "11"};
            return guessedLetters;
        }

        //få alla indexes som är kvar i listan
        public List<int> getIndexes(string[] guessedLetters)
        {
            List<int> indexes = new List<int>(); //dynamisk temp lista

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                if (tryInt.TestStringIsInt(guessedLetters[i]))
                {
                    indexes.Add(int.Parse(guessedLetters[i]));
                }
            }
            return indexes;
        }

    }
}

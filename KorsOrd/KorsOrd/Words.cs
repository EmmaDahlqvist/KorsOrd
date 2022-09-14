using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    class Words
    {
        string[] words; //orden 
        char[] letters; //ordens alla bokstäver
        string[] guesses; 
        char[] guessedLetters; //gissade bokstäver

        public Words(string[] words)
        {
            this.words = words; //lägg in ord
            for(int i = 0; i < words.Length; i++) {
                letters = words[i].ToCharArray(); //bokstäverna
            }

            guessedLetters = letters; //guessedLetters är lika stor som letters

            for(int i = 0; i < letters.Length; i++)
            {
                char temp = (char) i;
                guessedLetters[i] = temp; //byt ut guessedLetters till indexes
            }
        }

        public string[] getWords()
        {
            return words;
        }

        public char[] getLetters()
        {
            return letters;
        }

        public char[] getGuessedLetters()
        {
            return guessedLetters;
        }

        public void changeGuessedLetters(int index, char letter)
        {
            guessedLetters[index] = letter;
        }
    }
}

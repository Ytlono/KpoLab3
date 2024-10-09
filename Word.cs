using System.Text.RegularExpressions;

namespace Lab3
{
    public enum WordInitialTypes
    {
        Unknown,
        Consonant, // Согласная
        Vowel      // Гласная
    }

    public class Word : Token
    {
        public string word;
        private WordInitialTypes wordInitialType;

        public Word(string word) : base(word)
        {
            this.word = word;
        }

        public WordInitialTypes WordInitialType
        {
            get { return wordInitialType; }
            set { wordInitialType = value; }
        }

        public override string ToString()
        {
            return word;
        }

        public void DetermineWordInitialType()
        {
            //^      - начало строки
            //[^...] - отрицание. Букв меньше писать :)
            if (Regex.IsMatch(word, @"^[^aeiouAEIOUаеёиоуыэюяАЕЁИОУЫЭЮЯ]"))
            {
                WordInitialType = WordInitialTypes.Consonant;
            }
            else
            {
                WordInitialType = WordInitialTypes.Vowel;
            }
        }
    }
}

namespace Lab3
{
    public class Word : Token
    {
        public string word;
        public int wordLength;

        public Word() { }

        public override string ToString()
        {
            return word;
        }
    }
}

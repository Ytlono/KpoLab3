namespace Lab3
{
    public class Sentence
    {
        public List<Token> tokens;
        public int sentenceLengthByWord;
        public int sentenceLengthBySymbols;

        public Sentence()
        {
            tokens = new List<Token>();
        }
    }
}

namespace Lab3
{
    public class Sentence
    {
        public List<Token> tokens;
        private int sentenceLengthByWord = 0;
        private int sentenceLengthByChar = 0;

        public Sentence()
        {
            tokens = new List<Token>();
        }

        public int SentenceLengthByWord
        {
            get { return sentenceLengthByWord; }
            set { sentenceLengthByWord = value; }
        }
        public int SentenceLengthByChar
        {
            get { return sentenceLengthByChar; }
            set { sentenceLengthByChar = value; }
        }

        public void CalculateSentenceLengthByWord()
        {
            //SentenceLengthByWord = tokens.Count(type => type is Word);
            foreach (var token in tokens) {
                if (token is Word)
                {
                    SentenceLengthByWord++;
                }
            }
        }

        public void CalculateSentenceLengthByChar()
        {
            foreach (Token token in tokens)
            {
                SentenceLengthByChar = SentenceLengthByChar + token.tokenLength;
            }
        }

        public override string ToString()
        {
            return string.Join(" ", tokens.Select(t => t.ToString()));
        }
    }

}

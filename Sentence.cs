namespace Lab3
{
    public class Sentence
    {
        public List<Token> tokens;
        private int sentenceLengthByWord = 0; 

        public Sentence()
        {
            tokens = new List<Token>();
        }

        public int SentenceLengthByWord
        {
            get { return sentenceLengthByWord; }
            set { sentenceLengthByWord = SentenceLengthByWord; }
        }

        public void CalculateSentenceLengthByWord()
        {
            SentenceLengthByWord = tokens.Count(type => type is Word);
        }

        public override string ToString()
        {
            return string.Join(" ", tokens.Select(t => t.ToString()));
        }
    }

}

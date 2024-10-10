namespace Lab3
{
    public enum SentenceTypes
    {
        Unknown,
        Statement,   // Повествовательное
        Question, // Вопросительное
        Exclamatory,   // Восклицательное
    }

    public class Sentence
    {
        public List<Token> tokens; 
        private int sentenceLengthByWord;
        private int sentenceLengthByChar;
        private SentenceTypes sentenceType;

        public Sentence()
        {
            this.tokens = new List<Token>();
            this.sentenceLengthByWord = 0;
            this.sentenceLengthByChar = 0;
            this.sentenceType = SentenceTypes.Unknown;
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

        public SentenceTypes SentenceType
        {
            get { return sentenceType; }
            set { sentenceType = value; }
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

        public void DetermineSentenceType()
        {
            var lastToken = tokens.LastOrDefault(); 

            if (lastToken is Punctuation punctuation) 
            {
                switch (punctuation.symbol)
                {
                    case "?":
                        SentenceType = SentenceTypes.Question;
                        break;
                    case "!":
                        SentenceType = SentenceTypes.Exclamatory;
                        break;
                    case ".":
                        SentenceType = SentenceTypes.Statement;
                        break;
                    default:
                        SentenceType = SentenceTypes.Unknown; 
                        break;
                }
            }
            else
            {
                SentenceType = SentenceTypes.Unknown; 
            }
        }


        public override string ToString()
        {
            return string.Join(" ", tokens.Select(t => t.ToString()));
        }
    }

}

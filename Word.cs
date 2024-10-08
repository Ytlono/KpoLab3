namespace Lab3
{
    public class Word : Token
    {
        public string word;

        public Word(string word) : base(word)
        { 
            this.word = word;
        }
      
        public override string ToString()
        {
            return word;
        }
    }
}

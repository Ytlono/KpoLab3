namespace Lab3
{
    public class Punctuation : Token
    {
        public string symbol;

        public Punctuation(string symbol):base(symbol) 
        {
            this.symbol = symbol;
        }
        public override string ToString()
        {
            return symbol;
        }
    }
}

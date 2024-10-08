namespace Lab3
{
    public abstract class Token
    {
        public int tokenLength { get; set; }

        protected Token(string value)
        {
            tokenLength = value.Length;
        }
    }
}

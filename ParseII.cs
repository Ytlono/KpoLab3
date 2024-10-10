using System.Dynamic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab3
{
    public class ParseII
    {
        private string inputFilePath;
        private string inputText;
        private Text parsedText;
        

        public ParseII(string inputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.parsedText = new Text();
        }

        public void Run()
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            inputText = reader.ReadToEnd();

            List<string> sentencesList = TextToSentences(inputText);
            SentencesToTokens(sentencesList);
        }

        public List<string> TextToSentences(string text)
        {
            List<string> sentenceList = Regex.Split(text, @"(?<=[.!?])\s+").ToList();
            return sentenceList;
        }

        public void SentencesToTokens(List<string> sentenceList)
        {
            foreach (var sentence in sentenceList)
            {
                Sentence newSentence = new Sentence(); 

                var matches = Regex.Matches(sentence, @"\w+|[.,!?]");
                foreach (var match in matches)
                {
                    string token = match.ToString();

                    if (Regex.IsMatch(token, @"\w+"))
                    {
                        Word newWord = new Word(token);
                        newSentence.tokens.Add(newWord);
                        newWord.DetermineWordInitialType();
                    }
                    else if (Regex.IsMatch(token, @"[.,!?]"))
                    {
                        Punctuation newPunctuation = new Punctuation(token);
                        newSentence.tokens.Add(newPunctuation);
                    }
                }
               
                newSentence.CalculateSentenceLengthByWord();
                newSentence.CalculateSentenceLengthByChar();
                newSentence.DetermineSentenceType();
                parsedText.sentenceTokenList.Add(newSentence); 
            }
        }

        public Text GetParsedText()
        {
            return parsedText;
        }


        public void Print()
        {
            foreach (var sentence in parsedText.sentenceTokenList)
            {
                foreach (var token in sentence.tokens)
                {
                    if (token is Word word)
                    {
                        Console.WriteLine(word.WordSetGet); 
                    }
                    else if (token is Punctuation punctuation)
                    {
                        Console.WriteLine(punctuation.symbol); 
                    }
                }
            }
        }
    }
}

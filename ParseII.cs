using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lab3
{
    public class ParseII
    {
        private string fileIn;
        public string text;
        public Text tokenSentences;
        public Sentence sentences;
        public Word words;
        public Punctuation punctuations;

        public ParseII(string fileIn)
        {
            this.fileIn = fileIn;
            this.tokenSentences = new Text();
            this.sentences = new Sentence();
            this.words = new Word();
            this.punctuations = new Punctuation();

        }
        public void Run()
        {
            using StreamReader reader = new StreamReader(fileIn);
            text = reader.ReadToEnd();

            List<string> sentencesList = TextToSentences(text);

            SentencesToTokens(sentencesList);
        }

        public List<string> TextToSentences(string text)
        {   
            List<string> sentenceList = new List<string>();
            sentenceList = Regex.Split(text, @"(?<=[.!?])\s+").ToList();
            return sentenceList;
        }

        public void SentencesToTokens(List<string> sentenceList)
        {
            
            foreach (var sentence in sentenceList) {

                var matches = Regex.Matches(sentence, @"\w+|[.,!?]");

                foreach (var match in matches)
                {
                    string token = match.ToString();

                    if (Regex.IsMatch(token, @"\w+"))
                    {
                        words.word = token;
                        sentences.tokens.Add(words);
                    }
                    else if(Regex.IsMatch(token, @"[.,!?]"))
                    { 
                        punctuations.symbol = token;
                        sentences.tokens.Add(punctuations);
                    }
                    
                }
                tokenSentences.sentenceTokenList.Add(sentences);
            }

        }

        private void Print()
        {
            // Проход по каждому предложению в списке предложений
            foreach (var sentence in tokenSentences.sentenceTokenList)
            {
                // Проход по каждому токену (слово или знак препинания) в предложении
                foreach (var token in sentence.tokens)
                {
                    // Если токен — это слово
                    if (token is Word word)
                    {
                        Console.WriteLine(word.word);
                    }
                    // Если токен — это знак препинания
                    else if (token is Punctuation punctuation)
                    {
                        Console.WriteLine(punctuation.symbol);
                    }
                }
            }
        }


    }

}

using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab3
{
    public class ParseII
    {
        private string inputFilePath;
        public string inputText;
        public Text parsedText;

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

            Print();
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
                Sentence newSentence = new Sentence(); // Новый объект предложения для каждого цикла

                var matches = Regex.Matches(sentence, @"\w+|[.,!?]");
                foreach (var match in matches)
                {
                    string token = match.ToString();

                    if (Regex.IsMatch(token, @"\w+"))
                    {
                        // Создаем новый объект Word для каждого найденного слова
                        Word newWord = new Word { word = token };
                        newSentence.tokens.Add(newWord);
                    }
                    else if (Regex.IsMatch(token, @"[.,!?]"))
                    {
                        // Создаем новый объект Punctuation для каждого знака препинания
                        Punctuation newPunctuation = new Punctuation { symbol = token };
                        newSentence.tokens.Add(newPunctuation);
                    }
                }

                parsedText.sentenceTokenList.Add(newSentence); // Добавляем предложение в общий список
            }
        }


        private void Print()
        {
            foreach (var sentence in parsedText.sentenceTokenList)
            {
                foreach (var token in sentence.tokens)
                {
                    if (token is Word word)
                    {
                        Console.WriteLine(word.word); // Вывод слова
                    }
                    else if (token is Punctuation punctuation)
                    {
                        Console.WriteLine(punctuation.symbol); // Вывод знака препинания
                    }
                }
            }
        }
    }
}

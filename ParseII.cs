using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
                Sentence newSentence = new Sentence(); // Новый объект предложения

                var matches = Regex.Matches(sentence, @"\w+|[.,!?]");
                foreach (var match in matches)
                {
                    string token = match.ToString();

                    if (Regex.IsMatch(token, @"\w+"))
                    {
                        Word newWord = new Word { word = token }; // Новый объект Word
                        newSentence.tokens.Add(newWord);
                    }
                    else if (Regex.IsMatch(token, @"[.,!?]"))
                    {
                        Punctuation newPunctuation = new Punctuation { symbol = token }; // Новый объект Punctuation
                        newSentence.tokens.Add(newPunctuation);
                    }
                }

                parsedText.sentenceTokenList.Add(newSentence); // Добавляем предложение в список
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

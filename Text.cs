using System.Dynamic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab3
{
    public class Text:IText
    {
        public List<Sentence> sentenceTokenList;

        public Text()
        {
            this.sentenceTokenList = new List<Sentence>();
        }

        public void SortSentencesByWordCount() 
        {
            var sortedSentences = sentenceTokenList.OrderBy(sentence => sentence.SentenceLengthByWord);

            foreach (var sentence in sortedSentences)
            {
                Console.WriteLine(sentence.ToString());
                Console.WriteLine(sentence.SentenceLengthByWord + "\n");
            }
            Console.ReadKey(true);
        }

        public void SortSentencesByLength()
        {
       
            var sortedSentences = sentenceTokenList.OrderBy(sentence => sentence.SentenceLengthByChar);
            foreach (var sentence in sortedSentences)
            {
                Console.WriteLine(sentence.ToString());
                Console.WriteLine(sentence.SentenceLengthByChar + "\n");
            }
            Console.ReadKey(true);
        }

        public void FindWordsInQuestionsByLength(int length)
        {
            bool found = false;

            foreach(var sentence in sentenceTokenList)
            {
                if(sentence.SentenceType == SentenceTypes.Question) 
                {
                    foreach (var token in sentence.tokens)
                    {
                        if(token is Word && token.tokenLength == length)
                        {
                            found = true;
                            Console.WriteLine(token.ToString());
                        }

                    }
                }
            }
            string result = found ? "" : "Not found";
            Console.WriteLine(result);
            Console.ReadKey(true);
        }

        public void RemoveWordsByLengthStartingWithConsonant(int length)
        {
            var filteredSentence = new List<Sentence>(sentenceTokenList);

            foreach (var sentence in filteredSentence)
            {
                sentence.tokens.RemoveAll(token => token is Word word && word.WordInitialType == WordInitialTypes.Consonant && token.tokenLength == length);
            }

            foreach (var sentence in filteredSentence)
            {
                Console.WriteLine(sentence.ToString());
            }
            Console.ReadKey(true);
        }


        public void ReplaceWordsByLengthInSentence(int sentenceIndex, int length, string replacement)
        {

        }

        public void RemoveStopWords(string[] stopWords)
        {

        }







        //public int WordCharCount()
        //{
        //    int lengthWord = 0;

        //    foreach (var sentence in this.sentenceTokenList)
        //    {
        //        foreach (var token in sentence.tokens)
        //        {
        //            if (token is Word wordToken)
        //            {
        //                 lengthWord = wordToken.word.Length;
        //            }
        //        }
        //    }
        //    return lengthWord;
        //}


    }
}

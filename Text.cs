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

        }

        public void SortSentencesByLength()
        {

        }
        public List<string> FindWordsInQuestionsByLength(int length)
        {
            return ["ff","ff"];
        }
        public void RemoveWordsByLengthStartingWithConsonant(int length)
        {

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

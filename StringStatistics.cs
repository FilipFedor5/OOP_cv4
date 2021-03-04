using System;
using System.Collections.Generic;
using System.Text;

namespace cv4
{
    class StringStatistics
    {
        private string Text;
        public StringStatistics(string text)
        {
            Text = text;
        }
        public string[] SplitStringToArray()
        {
            
            char[] separators = new char[] { ' ', '.', ',', ';', '!', '?', '\n','(',')' };
            return Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        public int NumOfWords()
        {
            return SplitStringToArray().Length;
        }
        public int NumOfRows()
        {
            return Text.Split('\n').Length;
        }

        public int NumOfSentences()
        {
            int number = 0;
            for(int i =Text.IndexOf('.'); i< Text.Length; i++)
            {
                if (i == -1) break;
                if (i == Text.Length-1)
                {
                    number++;
                    continue;
                }
                if(i == Text.Length - 2)
                {
                    if (Text[Text.Length-1] == ' ') number++;
                    continue;
                }
                if ((Text[i] == '.'||Text[i] == '!' || Text[i] == '?') && (Text[i + 1] == ' ') && char.IsUpper(Text[i + 2]))
                {
                    number++;
                    
                }
                if ((Text[i] == '.' || Text[i] == '!' || Text[i] == '?') && (Text[i + 1] == '\n') )
                {
                    number++;

                }
            }
            return number;
        }

        public string[] LongestWords()
        {
            int lengthOfWord = 0;
            int numOfLongestWords = 0;

            string[] textArray = SplitStringToArray();
            for(int i =0; i < textArray.Length; i++)
            {
                if (textArray[i].Length > lengthOfWord)
                {
                    lengthOfWord = textArray[i].Length;
                    numOfLongestWords = 1;
                }else if (textArray[i].Length == lengthOfWord)
                {
                    numOfLongestWords++;
                }
            }
            string[] longest = new string[numOfLongestWords];
            for (int i = 0; i < textArray.Length; i++)
            {
                if (textArray[i].Length == lengthOfWord)
                {
                    
                    longest[Array.IndexOf(longest,null)] = textArray[i];
                }
            }
            return longest;

        }
        public string[] ShortestWords()
        {
            int lengthOfWord = int.MaxValue;
            int numOfShortestWords = 0;

            string[] textArray = SplitStringToArray();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (textArray[i].Length < lengthOfWord)
                {
                    lengthOfWord = textArray[i].Length;
                    numOfShortestWords = 1;
                }
                else if (textArray[i].Length == lengthOfWord)
                {
                    numOfShortestWords++;
                }
            }
            string[] shortest = new string[numOfShortestWords];
            for (int i = 0; i < textArray.Length; i++)
            {
                if (textArray[i].Length == lengthOfWord)
                {

                    shortest[Array.IndexOf(shortest, null)] = textArray[i];
                }
            }
            return shortest;
        }
        public string[] SortText()
        {
            string[] textArray = SplitStringToArray();
            Array.Sort(textArray);
            return textArray;
        }
        public string[] MostCommonWords()
        {
            string[] textArray = SplitStringToArray();
            int numOfWords = 0;
            int numOfMostCommon = 0;
            List<string> commonWords = new List<string>();

            for (int i = 0; i < textArray.Length; i++)
            {
                numOfWords = 0;
                for (int j = 0; j < textArray.Length; j++)
                {
                    
                    if (textArray[i] == (textArray[j]))
                    {
                        numOfWords++;
                    }
                }
                if (numOfWords > numOfMostCommon)
                {
                    numOfMostCommon = numOfWords;
                    numOfWords = 1;
                    commonWords.Clear();
                    commonWords.Add(textArray[i]);
                }
                else if (numOfWords == numOfMostCommon)
                {
                    numOfWords++;
                    if(!commonWords.Contains(textArray[i])) commonWords.Add(textArray[i]);
                }
            }
            return commonWords.ToArray();
            

        }

        //☣☣☣☣☣☣☣☣☣☣☣☣
        public bool Isinfected()
        {
            string text = Text;
            text.ToLower();
            return (text.Contains("covid")|| text.Contains("sars-cov-2")); //doesnt need to contain condition for covid-19 because covid is allready in this word
        }
        //☣☣☣☣☣☣☣☣☣☣☣☣

    }
}

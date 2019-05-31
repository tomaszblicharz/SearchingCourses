using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchingCourses
{
    internal class ProfanityFinder
    {
        private string[] badWords;
        

        public ProfanityFinder()
        {
            var dictFile = File.ReadAllText(path: "profanities.txt");
            dictFile = dictFile.Replace("*", "");
            dictFile = dictFile.Replace("(", "");
            dictFile = dictFile.Replace(")", "");

            badWords = dictFile.Split(new[] { "\",\"" }, StringSplitOptions.None);

        }

        public string Censore(string text)
        {
            foreach (var word in badWords)
            
                text = RemoveBadWord(text, word);
            
            return text;

        }

        public int CountBadWords(string text)
        {
            var badWordsAmount = 0;
            foreach (var word in badWords)
            
                if (text.Contains(word))
                    badWordsAmount = badWordsAmount + 1;
                return badWordsAmount;
           
        }

        public Dictionary<string, int> FindTopBadWords(string lyrics)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in badWords)
            {
                int occurrencesOfWord = CalcccurrencesOf(word, lyrics);

                if (occurrencesOfWord > 0)
                    dict[word] = occurrencesOfWord;

            }
            return dict;
        }

        private int CalcccurrencesOf(string word, string lyrics)
        {
            var pattern = "\\b" + word + "\\b";
            return Regex.Matches(lyrics, pattern).Count;
       


        }
       

        static string RemoveBadWord(string text, string word)
        {
            var pattern = "\\b" +word+ "\\b";
                return Regex.Replace(text, pattern, "____",RegexOptions.IgnoreCase);
        }
        public string GetBadWordsSummary(Song song)
        {
            var summary = "";
            var BadWordsAmounts = FindTopBadWords(song.lyrics);

            foreach (var word in BadWordsAmounts.OrderBy(word=>word.Value))

                summary = summary + "\n" + word.Key + "-" + word.Value;

               return summary; 
        }
    }
}


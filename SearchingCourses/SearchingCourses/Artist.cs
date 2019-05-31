using System;
using System.Collections.Generic;

namespace SearchingCourses
{
    class Artist
    {
        public string name;
        public List<string> songTitles;

        public int wordCount;
        public int swearCount; 

        public Artist(string name)
        {
            this.name = name;
        }

        public void CalculateSwearAndWordCount()
        {
            var profanityFinder = new ProfanityFinder();
            wordCount = 0;
            swearCount = 0;
            foreach (var title in songTitles)
            {
                var song = new Song(name, title);
                swearCount += profanityFinder.CountBadWords(song.lyrics);
                wordCount += song.CountWords();
            }


        }
            public void DisplayStatistics()
            {
                int ProfranityIndex = wordCount / swearCount;
                Console.WriteLine("Dla artysty: " + name + " co " + ProfranityIndex + " słowo to przekleństwo.");

         }

    }
}

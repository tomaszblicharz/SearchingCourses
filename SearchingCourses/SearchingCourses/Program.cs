using SearchingCurses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingCourses
{
    class Program
    {
        public static void Main()
        {
            var strona = WebCache.GetOrDownload("http://google.com");
            var eminem = new Artist("Eminem");
            eminem.songTitles = new List<string>
            {
                "Lose Yourself",
                "Not Afraid",
                "Sing for the Moment"
            };
            eminem.CalculateSwearAndWordCount();
            eminem.DisplayStatistics();

            var nickiMinaj = new Artist("Nicki Minaj");
            nickiMinaj.songTitles = new List<string>
            {
                "Bang Bang",
                "Super Bass",
                "Anaconda",
                "Starships",
                "nie ma takiej"
            };

            nickiMinaj.CalculateSwearAndWordCount();
            nickiMinaj.DisplayStatistics();



            var profanityFinder = new ProfanityFinder();

          

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }


}
        
    

